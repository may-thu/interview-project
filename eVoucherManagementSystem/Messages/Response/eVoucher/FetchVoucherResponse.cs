

namespace eVoucherManagementSystem.Messages.Response.eVoucher
{
    using System.Collections.Generic;
    using DataTransferObjects;
    public class FetchVoucherResponse : ResponseBase
    {
        public int eVouchersPerPage { get; set; }
        public bool HasPreviousPages { get; set; }
        public bool HasNextPages { get; set; }
        public int CurrentPage { get; set; }
        public int[] Pages { get; set; }
        public IEnumerable<eVoucherDto> eVouchers { get; set; }   
    }   
}
