using eVoucherManagementSystem.Messages.Request.eVoucher;
using eVoucherManagementSystem.Messages.Response.eVoucher;
using eVoucherManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Services
{
    public interface IeVoucherService
    {
        GetVoucherResponse GetVoucher(GetVoucherRequest getvoucherRequest);
        FetchVoucherResponse GetVouchers(FetchVoucherRequest fetchVoucherRequest);
        CreateEVoucherResponse SaveEVoucher(CreateVoucherRequest createVoucherRequest);
        UpdateEVoucherResponse EditEVoucher(UpdateEVoucherRequest updateEVoucherRequest);
    }
}
