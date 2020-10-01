using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Models
{
    public class eVoucher
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string ImageURL { get; set; }
        public Decimal Amount { get; set; }
        public Decimal PurchaseValue { get; set; }
        public IEnumerable<eVoucherPaymentMode> eVoucherPaymentMode { get; set; }

        public int Quantity { get; set; }
        public BuyType BuyType { get; set; }

        public int MaxCanBuyeVoucher { get; set; }

        public int GiftPerUserBuy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public eVoucherStatus EVoucherStatus { get; set; }


    }

}
