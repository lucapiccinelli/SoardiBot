using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using Microsoft.Owin.Testing;
using Soardibot.Controllers.Dto.SendMessage;
using Xunit;

namespace Soardibot.Tests.Acceptance
{
    
    public class Acceptance
    {
        [Fact]
        public async void ICan_Send_AMessagge()
        {
            var testServer = TestServer.Create<SoardiBotStart>();
            var response = await testServer.CreateRequest("http://testserver/api/v1/sendmessage")
                .And(request => request.Content = new ObjectContent<SendMessageDto>(new SendMessageDto()
                {
                    Text = "bla",
                    ToId = 494523457
                }, new JsonMediaTypeFormatter()))
                .PostAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void OnMalformedInput_ItReturn_BadRequest()
        {
            var testServer = TestServer.Create<SoardiBotStart>();
            var response = await testServer.CreateRequest("http://testserver/api/v1/sendmessage")
                .And(request => request.Content = new ObjectContent<string>("blaaaaaa", new JsonMediaTypeFormatter()))
                .PostAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
