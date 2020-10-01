using eVoucherManagementSystem.Database;
using eVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Repositories.Implementations
{
    public class eStoreRepository : IeStoreRepository
    {
        private eVoucherMSDBContext _context;

        public eStoreRepository(eVoucherMSDBContext context)
        {
            _context = context;
        }
        public bool IsValidPromoCode(string PromoCode, string PhoneNo)
        {
            QRCode qrCode = _context.QRCodes.Where(x => x.PromoCode == PromoCode).FirstOrDefault();
            if(qrCode != null)
            {
                var UnusedList = _context.PurchaseEVouchers.Where(x => x.QRCodeId == qrCode.Id && x.PhoneNo == PhoneNo && x.IsUsed == false).ToList();
                var status = _context.EVouchers.Where(x => x.Id == qrCode.eVoucherId).FirstOrDefault();
                if (status.EVoucherStatus == eVoucherStatus.Active && status.ExpiryDate < DateTime.Now)
                {
                    if(UnusedList.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void SavePurchaseEVoucher(PurchaseEVoucher purchase)
        {
            _context.PurchaseEVouchers.Add(purchase);
            _context.SaveChanges();
        }

        public IEnumerable<PurchaseEVoucher> GetPurchaseEVouchersByCustomer(Guid customerId)
        {
            return _context.PurchaseEVouchers.Where(x => x.CustomerId == customerId).ToList();
        }

        
    }
}
