namespace eVoucherManagementSystem.Messages.Response.eStore
{
    using eVoucherManagementSystem.Messages.DataTransferObjects;
    public class GetVoucherStatusResponse:ResponseBase
    {
        public bool IsValid { get; set; }
        
    }
}
