using eVoucherManagementSystem.Messages.Request.QRCode;
using eVoucherManagementSystem.Messages.Response.QRCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Services
{
    public interface IQRCodeService
    {
        CreateQRCodeResponse CreateQRCode(CreateQRCodeRequest createQRCodeRequest);
    }
}
