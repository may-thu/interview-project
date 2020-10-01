using eVoucherManagementSystem.Messages.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Messages.Request.QRCode
{
    public class CreateQRCodeRequest
    {
        
        public Guid eVoucharId { get; set; }
       
    }
}
