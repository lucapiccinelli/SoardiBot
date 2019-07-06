using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Soardibot.Controllers.Dto.SendMessage;

namespace Soardibot.Controllers
{
    public class ControllerHelper
    {
        private readonly ApiController _controller;

        public ControllerHelper(ApiController controller)
        {
            _controller = controller;
        }

        public async Task<IHttpActionResult> RunTask<T>(T request, Func<Task<IHttpActionResult>> task)
        {
            try
            {
                if (!ValidateRequest(request))
                {
                    return await ImpossibleToParseRequestDto();
                }

                return await task();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _controller);
            }
        }

        private async Task<IHttpActionResult> ImpossibleToParseRequestDto()
        {
            string textContent = "Null request here";
            if (_controller.Request != null)
            {
                textContent = await _controller.Request.Content.ReadAsStringAsync();
            }
            return new BadRequestErrorMessageResult($"Check your input. Probably it is in bad form: {textContent}", _controller);
        }

        private static bool ValidateRequest<T>(T request)
        {
            return request != null;
        }
    }
}