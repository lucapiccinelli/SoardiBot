using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Soardibot.Controllers.Dto.SendMessage;

namespace Soardibot.Controllers
{
    public class SendmessageController : ApiController
    {
        public async Task<IHttpActionResult> Post([FromBody]SendMessageDto request)
        {
            if (request == null)
            {
                string textContent = await Request.Content.ReadAsStringAsync();
                return BadRequest($"Check your input. Probably it is in bad form: {textContent}");
            }
            return Ok();
        }
    }
}