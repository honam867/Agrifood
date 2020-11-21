namespace AspNetCore.Common.Models
{
    public class GrantedContractPermission
    {
        // Contract Service Permission
        public bool CanViewContractService { get; set; }
        public bool CanCreateContractService { get; set; }
        public bool CanEditContractService { get; set; }
        public bool CanDeleteContractService { get; set; }
        public bool CanSubmitContractService { get; set; }
        public bool CanApproveContractService { get; set; }
        public bool CanRejectContractService { get; set; }
        public bool CanSendContractService { get; set; }
        public bool CanPrintContractService { get; set; }
        public bool CanRecallContractService { get; set; }
        public bool CanCancelContractService { get; set; }

        // Contract Commerce Permission
        public bool CanViewContractCommerce { get; set; }
        public bool CanCreateContractCommerce { get; set; }
        public bool CanEditContractCommerce { get; set; }
        public bool CanDeleteContractCommerce { get; set; }
        public bool CanSubmitContractCommerce { get; set; }
        public bool CanApproveContractCommerce { get; set; }
        public bool CanRejectContractCommerce { get; set; }
        public bool CanSendContractCommerce { get; set; }
        public bool CanPrintContractCommerce { get; set; }
        public bool CanRecallContractCommerce { get; set; }
        public bool CanCancelContractCommerce { get; set; }
    }
}
