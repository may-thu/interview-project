namespace eVoucherManagementSystem.Messages.Request.eStore
{
    using eVoucherManagementSystem.Messages.DataTransferObjects;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

    public class GetVoucherStatusRequest
    {        
        public string PromoCode { get; set; }
        public string PhoneNo { get; set; } 
    }
}
