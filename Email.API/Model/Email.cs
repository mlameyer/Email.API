using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email.API.Model
{
    public class Email
    {
        public string Name { get; set; }
        public string sendEmailAddress { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
    }
}
