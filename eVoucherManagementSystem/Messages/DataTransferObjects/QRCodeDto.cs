using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.DataTransferObjects
{
    public class QRCodeDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid eVoucherId { get; set; }
        [Required]
        public byte[] QRCodeImg { get; set; }
        [Required]
        public string QRCodeImgURL { get; set; }
        [Required]
        [StringLength(10)]
        public string PromoCode { get; set; }
        public eVoucherDto eVoucher { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
