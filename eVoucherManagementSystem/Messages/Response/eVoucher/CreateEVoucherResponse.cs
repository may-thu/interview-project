using eVoucherManagementSystem.Messages.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.Response.eVoucher
{
    public class CreateEVoucherResponse
    {
        public eVoucherDto eVoucher { get; set; }
    }
}
