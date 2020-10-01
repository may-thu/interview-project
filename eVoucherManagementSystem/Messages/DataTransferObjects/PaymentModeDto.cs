using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.DataTransferObjects
{
    public class PaymentModeDto
    {
        public int Id { get; set; }
        public string PaymentType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdtedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
