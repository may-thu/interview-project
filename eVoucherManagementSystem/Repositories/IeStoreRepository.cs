using eVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Repositories
{
    public interface IeStoreRepository
    {
        bool IsValidPromoCode(string PromoCode, string PhoneNo);
        void SavePurchaseEVoucher(PurchaseEVoucher purchase);
        IEnumerable<PurchaseEVoucher> GetPurchaseEVouchersByCustomer(Guid customerId);
    }
}
