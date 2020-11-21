using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models
{
    public class AddRolesToUserModelRq
    {
        public int UserId { get; set; }
        public List<RoleCreatedModelRq> Roles { get; set; }
    }
}
