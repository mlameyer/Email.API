using Email.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    [Produces("application/json")]
    [Route("api/SendMail")]
    public class SendMailController : Controller
    {
        private ISendEmailRepository _sendEmailRepository;

        public SendMailController(ISendEmailRepository sendEmailRepository)
        {
            _sendEmailRepository = sendEmailRepository;
        }
        // PUT api/values/5
        [HttpPost()]
        public IActionResult Post(string name, string sendEmailAddress, string subject, string message)
        {
            if(name == null || sendEmailAddress == null)
            {
                return BadRequest();
            }

            var result = _sendEmailRepository.SendEmail(name, sendEmailAddress, subject, message);

            if(!result)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}