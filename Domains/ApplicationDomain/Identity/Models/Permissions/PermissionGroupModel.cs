using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models.Permissions
{
    public class PermissionGroupModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
    }

    public class PermissionGroupModelMapper : Profile
    {
        public PermissionGroupModelMapper()
        {
            CreateMap<PermissionGroupModel, PermissionGroup>();
        }
    }
}
