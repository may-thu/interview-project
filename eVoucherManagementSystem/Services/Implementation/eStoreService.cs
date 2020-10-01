using eVoucherManagementSystem.Messages;
using eVoucherManagementSystem.Messages.Request.eStore;
using eVoucherManagementSystem.Messages.Response.eStore;
using eVoucherManagementSystem.Repositories;
using eVoucherManagementSystem.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVoucherManagementSystem.Services.Implementation
{
    public class eStoreService:IeStore
    {
        private readonly IeStoreRepository _eStoreRepository;
        private readonly IeVoucherRepository _ieVoucherRepository;
        private MessageMapper _messageMapper;
        public eStoreService(IeStoreRepository eStoreRepository, IeVoucherRepository eVoucherRepository)
        {
            _eStoreRepository = eStoreRepository;
            _ieVoucherRepository = eVoucherRepository;
            _messageMapper = new MessageMapper();
        }

        public GetVoucherStatusResponse IsValidPromo(GetVoucherStatusRequest request)
        {
            var result = _eStoreRepository.IsValidPromoCode(request.PromoCode, request.PhoneNo);
            List<string> msgList = new List<string>();
            if (result)
            {
                msgList.Add("Valid Promocode");
                GetVoucherStatusResponse response = new GetVoucherStatusResponse
                {
                    IsValid = true,
                    Messages = msgList
                };
                return response;
            }
            else
            {
                msgList.Add("Invalid Promocode");
                GetVoucherStatusResponse response = new GetVoucherStatusResponse
                {
                    IsValid = false,
                    Messages = msgList
                };
                return response;
            }
            
        }

        //public CreatePurchaseResponse MakePaymenteVoucher(CreatePurchaseVoucherRequest request)
        //{
        //    var e = _ieVoucherRepository.GetEVoucherPaymentModesByVoucherId(request.)
        //}





    }
}
