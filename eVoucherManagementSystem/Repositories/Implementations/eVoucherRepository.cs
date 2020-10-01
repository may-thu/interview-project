using eVoucherManagementSystem.Database;
using eVoucherManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Repositories.Implementations
{
    public class eVoucherRepository:IeVoucherRepository
    {
        private eVoucherMSDBContext _context;

        public eVoucherRepository(eVoucherMSDBContext context)
        {
            _context = context;
        }

        public eVoucher FindeVoucherId(Guid id)
        {
            var item = _context.EVouchers.Find(id);
            item.eVoucherPaymentMode = _context.EVoucherPaymentModes.Where(x => x.eVoucherId == item.Id).ToList();
            return item;
        }

        public IEnumerable<eVoucher> GetAlleVouchers()
        {
            var vouchers = _context.EVouchers;
            
            return vouchers;
        }

        public IEnumerable<eVoucherPaymentMode> GetEVoucherPaymentModesByVoucherId(Guid id)
        {
            IEnumerable<eVoucherPaymentMode> eVoucherPaymentModes = new List<eVoucherPaymentMode>();

            eVoucherPaymentModes = _context.EVoucherPaymentModes.Where(x => x.eVoucherId == id).ToList();
            return eVoucherPaymentModes;
        }
        public void SaveVoucher(eVoucher item)
        {
            _context.EVouchers.Add(item);
            _context.EVoucherPaymentModes.AddRange(item.eVoucherPaymentMode);
            _context.SaveChanges();
        }

        public void UpdateVoucher(eVoucher item)
        {
            _context.EVouchers.Update(item);
            _context.EVoucherPaymentModes.UpdateRange(item.eVoucherPaymentMode);
            _context.SaveChanges();
        }      
        public void DeleteVoucher(Guid id)
        {
            var item = _context.EVouchers.Where(x => x.Id == id).FirstOrDefault();
             _context.EVouchers.Remove(item);
            _context.SaveChanges();
        }
    }
}
