using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Soardibot.Controllers.Dto.SendMessage;
using Soardibot.Dto;
using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace Soardibot.Controllers
{
    public class SendmessageController : ApiController
    {
        private TelegramBotClient _telegramBotClient;
        private readonly string _botClientId;
        private readonly ControllerHelper _controllerHelper;

        public SendmessageController(Secrets secrets)
        {
            _botClientId = secrets.Telegram.Id;
            _controllerHelper = new ControllerHelper(this);
        }

        public async Task<IHttpActionResult> Post([FromBody]SendMessageDto request)
        {
            return await _controllerHelper.RunTask(request, () => SendMessage(request));
        }

        private async Task<IHttpActionResult> SendMessage(SendMessageDto request)
        {
            _telegramBotClient = new TelegramBotClient(_botClientId);
            try
            {
                await _telegramBotClient.SendTextMessageAsync(request.ToId, request.Text);
                return Ok();
            }
            catch (ApiRequestException ex)
            {
                if (ex.ErrorCode == 400)
                {
                    return BadRequest(ex.Message);
                }

                return InternalServerError(ex);
            }
        }
    }
}