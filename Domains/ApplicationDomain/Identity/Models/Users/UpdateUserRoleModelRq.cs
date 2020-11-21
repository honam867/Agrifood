using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models
{
    public class UpdateUserRoleModelRq
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}
