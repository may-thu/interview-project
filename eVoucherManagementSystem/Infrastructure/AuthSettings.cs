using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Infrastrature
{
    public class AuthSettings
    {
        public string Key { get; set; }
        public int ExpirationInMinutes { get; set; }
    }
}
