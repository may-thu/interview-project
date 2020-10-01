using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.Request.User
{
    public class LogInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
