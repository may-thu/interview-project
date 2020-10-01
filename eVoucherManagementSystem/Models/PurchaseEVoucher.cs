using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Models
{
    public class PurchaseEVoucher
    {
        public Guid Id { get; set; }
        public Guid eVoucherId { get; set; }
        public Guid CustomerId { get; set; }
        public int Qty { get; set; }
        public bool IsUsed { get; set; }
        public Guid QRCodeId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
