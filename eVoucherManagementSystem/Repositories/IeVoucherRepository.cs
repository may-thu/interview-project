using eVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Repositories
{
    public interface IeVoucherRepository
    {
        eVoucher FindeVoucherId(Guid id);
        IEnumerable<eVoucher> GetAlleVouchers();
        void SaveVoucher(eVoucher item);
        void UpdateVoucher(eVoucher item);
        void DeleteVoucher(Guid id);
        IEnumerable<eVoucherPaymentMode> GetEVoucherPaymentModesByVoucherId(Guid id);
    }
}
