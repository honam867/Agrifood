using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models.Permissions
{
    public class FarmerPermissionModel
    {
        public bool CanView { get; set; }
        public bool CanCreate { set; get; }
        public bool CanEdit { set; get; }
        public bool CanDelete { set; get; }
        public bool CanAccess { get; set; }
    }
    public class FarmerPermissionModelMapper : Profile
    {
        public FarmerPermissionModelMapper()
        {
            CreateMap<FarmerPermission, FarmerPermissionModel>();
        }
    }
}
