using eVoucherManagementSystem.Messages.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.Request.eVoucher
{
    public class UpdateEVoucherRequest
    {
        public Guid Id { get; set; }
        public eVoucherDto eVoucher { get; set; }
    }
}
