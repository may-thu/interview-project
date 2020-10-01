using eVoucherManagementSystem.Messages.DataTransferObjects;

namespace eVoucherManagementSystem.Messages.Response.eVoucher
{
    public class GetVoucherResponse : ResponseBase
    {
        public eVoucherDto eVoucher { get; set; }
    }
}
