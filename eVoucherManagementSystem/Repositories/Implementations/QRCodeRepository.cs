using eVoucherManagementSystem.Database;
using eVoucherManagementSystem.Messages.Request.QRCode;
using eVoucherManagementSystem.Migrations;
using eVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Repositories.Implementations
{
    public class QRCodeRepository:IQRCodeRepository
    {
        private eVoucherMSDBContext _context;

        public QRCodeRepository(eVoucherMSDBContext context)
        {
            _context = context;
        }

        public QRCode FindeQRCodeId(Guid id)
        {
            var item = _context.QRCodes.Find(id);
            item.eVoucher = _context.EVouchers.Where(x => x.Id == item.eVoucherId).FirstOrDefault();
            return item;
        }

        public bool CheckPromoCode(string promo)
        {
            var result = _context.QRCodes.Where(x => x.PromoCode == promo).Any();
            return result;
        }

        public IEnumerable<QRCode> GetAlleQRCodes()
        {
            var qrCodes = _context.QRCodes;

            return qrCodes;
        }
        public void CreateQRCode(QRCode item)
        {
            _context.QRCodes.Add(item);
            _context.SaveChanges();
        }

        public void UpdateQRCode(QRCode item)
        {
            _context.QRCodes.Update(item);            
            _context.SaveChanges();
        }
        public void DeleteQRCode(Guid id)
        {
            var item = _context.QRCodes.Where(x => x.Id == id).FirstOrDefault();
            _context.QRCodes.Remove(item);
            _context.SaveChanges();
        }
    }
}
