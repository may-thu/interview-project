using eVoucherManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Database
{
    public class eVoucherMSDBContext:DbContext
    {
        public eVoucherMSDBContext(DbContextOptions<eVoucherMSDBContext> options) : base(options) {
            Database.Migrate();
        }

        public DbSet<eVoucher> EVouchers { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<eVoucherPaymentMode> EVoucherPaymentModes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PurchaseEVoucher> PurchaseEVouchers { get; set; }

        public DbSet<QRCode> QRCodes { get; set; }

        public DbSet<User> Users { get; set; }
       
    }

    
}
