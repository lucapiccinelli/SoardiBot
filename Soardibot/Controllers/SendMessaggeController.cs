using System;
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

        public SendmessageController(Secrets secrets)
        {
            _botClientId = secrets.Telegram.Id;
        }

        public async Task<IHttpActionResult> Post([FromBody]SendMessageDto request)
        {

            try
            {
                if (request == null)
                {
                    string textContent = await Request.Content.ReadAsStringAsync();
                    return BadRequest($"Check your input. Probably it is in bad form: {textContent}");
                }
                _telegramBotClient = new TelegramBotClient(_botClientId);
                try
                {
                    await _telegramBotClient.SendTextMessageAsync(request.ToId, request.Text);
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
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            return Ok();
        }
    }
}