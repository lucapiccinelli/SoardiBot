using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using Microsoft.Owin.Testing;
using Soardibot.Controllers.Dto.SendMessage;
using Xunit;

namespace Soardibot.Tests.Acceptance
{

    public class TestServerFixture : IDisposable
    {
        public TestServer TestServer { get; }

        public TestServerFixture()
        {
            TestServer = TestServer.Create<SoardiBotStart>();
        }

        public void Dispose()
        {
            TestServer.Dispose();
        }
    }

    public class SendMessageToTheBotAcceptance : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _testServerFixture;
        private readonly TestServer _testServer;

        public SendMessageToTheBotAcceptance(TestServerFixture testServerFixture)
        {
            _testServerFixture = testServerFixture;
            _testServer = _testServerFixture.TestServer;
        }

        [Fact]
        public async void ICan_Send_AMessagge()
        {
            var response = await _testServer.CreateRequest("http://testserver/api/v1/sendmessage")
                .And(request => request.Content = new StringContent(
                "{" +
                    "\"text\":\"bla\"," +
                    "\"toId\":494523457" +
                "}", Encoding.UTF8, "application/json"))
                .PostAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void OnMalformedInput_ItReturns_BadRequest()
        {
            var response = await _testServer.CreateRequest("http://testserver/api/v1/sendmessage")
                .And(request => request.Content = new StringContent("blaaaaaa", Encoding.UTF8, "application/json"))
                .PostAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
