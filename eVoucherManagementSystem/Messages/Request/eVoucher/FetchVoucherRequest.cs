using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.Request.eVoucher
{
    public class FetchVoucherRequest
    {
        public int PageNumber { get; set; }
        public int VourchersPerPage { get; set; }
    }
}
