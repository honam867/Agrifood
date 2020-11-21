using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Common.Models
{
    public class GrantedQuotationPermission
    {
        // Quotaion Service Permission
        public bool CanViewQuotationService { get; set; }
        public bool CanCreateQuotationService { get; set; }
        public bool CanEditQuotationService { get; set; }
        public bool CanDeleteQuotationService { get; set; }
        public bool CanPrintQuotationService { get; set; }
        public bool CanRecallQuotationService { get; set; }
        public bool CanApproveQuotationService { get; set; }
        public bool CanRejectQuotationService { get; set; }
        public bool CanSendQuotationService { get; set; }
        public bool CanSubmitQuotationService { get; set; }
        public bool CanCancelQuotationService { get; set; }
        // Quotaion Commerce Permission
        public bool CanViewQuotationCommerce { get; set; }
        public bool CanCreateQuotationCommerce { get; set; }
        public bool CanEditQuotationCommerce { get; set; }
        public bool CanDeleteQuotationCommerce { get; set; }
        public bool CanPrintQuotationCommerce { get; set; }
        public bool CanRecallQuotationCommerce { get; set; }
        public bool CanApproveQuotationCommerce { get; set; }
        public bool CanRejectQuotationCommerce { get; set; }
        public bool CanSendQuotationCommerce { get; set; }
        public bool CanSubmitQuotationCommerce { get; set; }
        public bool CanCancelQuotationCommerce { get; set; }
    }
}
