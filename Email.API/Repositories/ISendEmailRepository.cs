using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email.API.Repositories
{
    public interface ISendEmailRepository
    {
        bool SendEmail(string name, string sendEmailAddress, string subject, string message);
    }
}
