using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Email.API.Repositories;
using Microsoft.AspNetCore.Http;
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
        public void Post(string name, string sendEmailAddress, string subject, string message)
        {
            _sendEmailRepository.SendEmail(name, sendEmailAddress, subject, message);
        }
    }
}