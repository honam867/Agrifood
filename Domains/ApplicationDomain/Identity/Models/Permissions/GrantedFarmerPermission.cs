using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models.Permissions
{
    public class GrantedFarmerPermission
    {
        // Quotaion Service Permission
        public bool CanViewFarmer { get; set; }
        public bool CanCreateFarmer { get; set; }
        public bool CanEditFarmer { get; set; }
        public bool CanDeleteFarmer { get; set; }
        //public bool CanPrintFarmer { get; set; }
        //public bool CanRecallFarmer { get; set; }
        //public bool CanApproveFarmer { get; set; }
        //public bool CanRejectFarmer { get; set; }
        //public bool CanSendFarmer { get; set; }
        //public bool CanSubmitFarmer { get; set; }
        //public bool CanCancelFarmer { get; set; }
   
    }
}
