using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models
{
    public class RoleCreatedModelRq
    {
        public string Name { get; set; }
    }

    public class RoleCreatedModelMapper : Profile
    {
        public RoleCreatedModelMapper()
        {
            CreateMap<RoleCreatedModelRq, Role>();
        }
    }
}
