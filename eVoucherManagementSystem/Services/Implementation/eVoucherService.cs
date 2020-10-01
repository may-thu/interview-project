using eVoucherManagementSystem.Messages;
using eVoucherManagementSystem.Messages.DataTransferObjects;
using eVoucherManagementSystem.Messages.Request.eVoucher;
using eVoucherManagementSystem.Messages.Response.eVoucher;
using eVoucherManagementSystem.Models;
using eVoucherManagementSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Services.Implementation
{
    public class eVoucherService:IeVoucherService
    {
        private readonly IeVoucherRepository _eVoucherRepository;
        private MessageMapper _messageMapper;
        public eVoucherService(IeVoucherRepository eVoucherRepository)
        {
            _eVoucherRepository = eVoucherRepository;
            _messageMapper = new MessageMapper();
        }

        public GetVoucherResponse GetVoucher(GetVoucherRequest getvoucherRequest)
        {
            GetVoucherResponse getVoucherResponse = null;

            if (getvoucherRequest.Id != null)
            {
                var voucher = _eVoucherRepository.FindeVoucherId(getvoucherRequest.Id);
                var eVoucherDto = _messageMapper.MapToeVoucherDto(voucher);

                getVoucherResponse = new GetVoucherResponse
                {
                    eVoucher = eVoucherDto
                };
            }

            return getVoucherResponse;
           
        }

        public FetchVoucherResponse GetVouchers(FetchVoucherRequest fetchVoucherRequest)
        {            
            int count = 0;
            IEnumerable<eVoucher> vouchers = new List<eVoucher>();            
            vouchers = _eVoucherRepository.GetAlleVouchers()
               .Where(x => x.EVoucherStatus == eVoucherStatus.Active)
               .Skip((fetchVoucherRequest.PageNumber - 1) * fetchVoucherRequest.VourchersPerPage)
                   .Take(fetchVoucherRequest.VourchersPerPage).ToList();   
            foreach(var item in vouchers)
            {
                item.eVoucherPaymentMode = _eVoucherRepository.GetEVoucherPaymentModesByVoucherId(item.Id);
            }
           

            var totalPages = (int)Math.Ceiling((decimal)count / fetchVoucherRequest.VourchersPerPage);

            int[] pages = Enumerable.Range(1, totalPages).ToArray();

            var voucherDtos = _messageMapper.MapToeVouchersDtos(vouchers);

            var response = new FetchVoucherResponse()
            {
                eVouchersPerPage = fetchVoucherRequest.VourchersPerPage,
                eVouchers = voucherDtos,
                HasPreviousPages = (fetchVoucherRequest.PageNumber > 1),
                CurrentPage = fetchVoucherRequest.PageNumber,
                HasNextPages = (fetchVoucherRequest.PageNumber < totalPages),
                Pages = pages
            };


            return response;
        }
        public CreateEVoucherResponse SaveEVoucher(CreateVoucherRequest createVoucherRequest)
        {
            var voucher = _messageMapper.MapToeVoucher(createVoucherRequest.eVoucher);
            voucher.Id = Guid.NewGuid();
            List<eVoucherPaymentMode> enumerable = new List<eVoucherPaymentMode>();            
            foreach (var item in createVoucherRequest.eVoucher.eVoucherPaymentModeDtos)
            {
                enumerable.Add(_messageMapper.MapToeVoucherPaymentMode(item));
            }
            voucher.eVoucherPaymentMode = enumerable;
            _eVoucherRepository.SaveVoucher(voucher);
            var voucherDto = _messageMapper.MapToeVoucherDto(voucher);
            var createResponse = new CreateEVoucherResponse {
                eVoucher = voucherDto
            };
            return createResponse;
        }

        public UpdateEVoucherResponse EditEVoucher(UpdateEVoucherRequest updateEVoucherRequest)
        {
            UpdateEVoucherResponse update = null;
            if(updateEVoucherRequest.Id == updateEVoucherRequest.eVoucher.Id)
            {
                var voucher = _messageMapper.MapToeVoucher(updateEVoucherRequest.eVoucher);
                _eVoucherRepository.UpdateVoucher(voucher);
                var voucherDto = _messageMapper.MapToeVoucherDto(voucher);
                update = new UpdateEVoucherResponse()
                {

                };
            }
            return update;
        }


    }
}
