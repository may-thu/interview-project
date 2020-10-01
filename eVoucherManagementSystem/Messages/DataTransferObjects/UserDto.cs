using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.DataTransferObjects
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
