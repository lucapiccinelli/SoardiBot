using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;
using Soardibot.Controllers;
using Soardibot.Controllers.Dto.SendMessage;
using Soardibot.Dto;
using Xunit;

namespace Soardibot.Tests.Controllers
{
    public class ControllerHelperTests
    {
        private readonly Mock<ApiController> _controllerMock;
        private readonly ControllerHelper _controllerHelper;

        public ControllerHelperTests()
        {
            _controllerMock = new Mock<ApiController>();
            _controllerHelper = new ControllerHelper(_controllerMock.Object);
        }

        [Fact]
        public async void ActionPerformsOk()
        {
            await _controllerHelper.RunTask(new object(), OkResult);
        }

        [Fact]
        public async void ActionHasBadParameters()
        {
            IHttpActionResult response = await _controllerHelper.RunTask<object>(null, OkResult);
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }

        [Fact]
        public async void ActionThrowsAnException()
        {
            IHttpActionResult response = await _controllerHelper.RunTask(new object(), () => throw new Exception("booooom"));
            Assert.IsType<ExceptionResult>(response);
        }

        private Task<IHttpActionResult> OkResult()
        {
            return Task.FromResult(new OkResult(_controllerMock.Object) as IHttpActionResult);
        }
    }
}
