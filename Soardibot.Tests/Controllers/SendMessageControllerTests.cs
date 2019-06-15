using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Soardibot.Controllers;
using Soardibot.Controllers.Dto.SendMessage;
using Soardibot.Dto;
using Xunit;

namespace Soardibot.Tests.Controllers
{
    public class SendMessageControllerTests
    {
        private readonly Secrets _secrets;

        public SendMessageControllerTests()
        {
            _secrets = Secrets.FromXml("secrets.xml");
        }


        [Fact]
        public async void Given_AChatId_AndAText_ItSends_TheMessage()
        {
            var request = new SendMessageDto()
            {
                Text = "bla",
                ToId = 494523457
            };

            var controller = new SendmessageController(_secrets);
            IHttpActionResult response = await controller.Post(request);
        }

        [Fact]
        public async void IfYouCant_ContactTheId_ItReturns_BadRequest()
        {
            var request = new SendMessageDto()
            {
                Text = "bla",
                ToId = 11
            };

            var controller = new SendmessageController(_secrets);
            IHttpActionResult response = await controller.Post(request);
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }

        [Fact]
        public async void OnGenericException_ItReturns_InternalServerError()
        {
            var request = new SendMessageDto()
            {
                Text = "bla",
                ToId = 11
            };

            var controller = new SendmessageController(new Secrets()
            {
                Telegram = new TelegramSecrets()
                {
                    Id = "banana"
                }
            });
            IHttpActionResult response = await controller.Post(request);
            Assert.IsType<ExceptionResult>(response);
        }

    }
}
