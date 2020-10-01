using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVoucherManagementSystem.Messages.Request.eVoucher;
using eVoucherManagementSystem.Messages.Response.eVoucher;
using eVoucherManagementSystem.Models;
using eVoucherManagementSystem.Repositories;
using eVoucherManagementSystem.Services;
using eVoucherManagementSystem.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVoucherManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class eVoucherController : ControllerBase
    {
        private readonly IeVoucherService _eVoucherService;
        public eVoucherController(IeVoucherService service)
        {
            _eVoucherService = service;
        }

        [HttpGet("{id}")]
        public ActionResult<GetVoucherResponse> GetVoucher(Guid id)
        {
            var geteVoucherRequest = new GetVoucherRequest
            {
                Id = id
            };
            var getVoucherResponse = _eVoucherService.GetVoucher(geteVoucherRequest);
            return getVoucherResponse;
            
        }

        [HttpGet]
        public ActionResult<FetchVoucherResponse> GetAllVouchers(int page = 1)
        {
            var fetchVoucherRequest = new FetchVoucherRequest
            {
                PageNumber = page,
                VourchersPerPage = 2
            };
            var fetchVouchersResponse = _eVoucherService.GetVouchers(fetchVoucherRequest);
            return fetchVouchersResponse;
            
        }

        [HttpPost]
        public ActionResult<CreateEVoucherResponse> PostVoucher(CreateVoucherRequest item)
        {
            var response = _eVoucherService.SaveEVoucher(item);
            return response;
        }

        [HttpPut()]
        public ActionResult<UpdateEVoucherResponse> PutVoucher(UpdateEVoucherRequest item)
        {
            var response = _eVoucherService.EditEVoucher(item);
            return response;
        }

        //[HttpDelete("{id}")]
        //public ActionResult DeleteVoucher(Guid id)
        //{

        //     _voucherRepository.DeleteVoucher(id);
        //    return Ok();
        //}
    }
}
