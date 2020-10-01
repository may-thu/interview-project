using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.Response.User
{
    public class RegisterResponse:ResponseBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
