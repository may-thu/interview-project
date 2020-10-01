using eVoucherManagementSystem.Messages.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.Response.QRCode
{
    public class CreateQRCodeResponse:ResponseBase
    {
        public QRCodeDto codeDto { get; set; }
    }
}
