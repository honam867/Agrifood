using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Entities
{
    public class PermissionGroup : EntityBase<int>
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public PermissionGroup() { }
        public PermissionGroup(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
