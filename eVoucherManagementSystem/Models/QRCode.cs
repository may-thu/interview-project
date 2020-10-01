using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Models
{
    public class QRCode
    {        
        public Guid Id { get; set; }
        public Guid eVoucherId { get; set; }
        public byte[] QRCodeImg { get; set; }
        public string PromoCode { get; set; }
        public eVoucher eVoucher { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
