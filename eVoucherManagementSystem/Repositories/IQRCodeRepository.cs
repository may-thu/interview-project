using eVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Repositories
{
    public interface IQRCodeRepository
    {
        QRCode FindeQRCodeId(Guid id);
        bool CheckPromoCode(string promo);
        IEnumerable<QRCode> GetAlleQRCodes();
        void CreateQRCode(QRCode item);
        void UpdateQRCode(QRCode item);
        void DeleteQRCode(Guid id);
    }
}
