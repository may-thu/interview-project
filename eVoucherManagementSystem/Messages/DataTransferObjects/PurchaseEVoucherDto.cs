using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.DataTransferObjects
{
    public class PurchaseEVoucherDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid eVoucherId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
        [Required]
        public int Qty { get; set; }
        public bool IsUsed { get; set; }
        [Required]
        public Guid QRCodeId { get; set; }
        public string Name { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public Decimal Amount { get; set; }
        [Required]
        public Decimal PurchaseValue { get; set; }
        [Required]
        public int PaymentModeId { get; set; }
    }
}
