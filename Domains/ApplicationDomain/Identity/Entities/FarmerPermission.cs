using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationDomain.Identity.Models.Permissions;
using AutoMapper;

namespace ApplicationDomain.Identity.Entities
{
    public class FarmerPermission : EntityBase<int>
    {
        public bool CanView { get; set; }
        public bool CanCreate { set; get; }
        public bool CanEdit { set; get; }
        public bool CanDelete { set; get; }
        public bool CanAccess { get; set; }
        public int PermissionGroupId { set; get; }
        public PermissionGroup PermissionGroup { set; get; }
    }
    public class FarmerPermissionMapper : Profile
    {
        public FarmerPermissionMapper()
        {
            CreateMap<FarmerPermissionModel, FarmerPermission>();
        }
    }
}
