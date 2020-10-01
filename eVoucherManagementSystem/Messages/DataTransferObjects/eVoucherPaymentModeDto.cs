using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.DataTransferObjects
{
    public class eVoucherPaymentModeDto
    {
        public int Id { get; set; }
        public int PaymentModeId { get; set; }

        public string PaymentType { get; set; }

        public Guid eVoucherId { get; set; }

        public decimal Discount { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }
    }
}
