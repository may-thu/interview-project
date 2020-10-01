using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVoucherManagementSystem.Messages.DataTransferObjects;
using eVoucherManagementSystem.Messages.Request.QRCode;
using eVoucherManagementSystem.Messages.Response.QRCode;
using eVoucherManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVoucherManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeGenerateController : ControllerBase
    {
        private readonly IQRCodeService _QRCodeService;
        public QRCodeGenerateController(IQRCodeService service)
        {
            _QRCodeService = service;
        }

        [HttpPost]
        public ActionResult<CreateQRCodeResponse> CreateQRCode(CreateQRCodeRequest createQRCodeRequest)
        {
            var response = _QRCodeService.CreateQRCode(createQRCodeRequest);
            return response;
        }
    }
}
