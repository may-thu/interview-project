using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Models
{
    public class PaymentMode
    {
        public int Id { get; set; }
       
        public string PaymentType { get; set; }        

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public bool isActive { get; set; }
    }
}
