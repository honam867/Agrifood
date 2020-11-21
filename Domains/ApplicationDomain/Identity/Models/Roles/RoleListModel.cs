using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models
{
    public class RoleListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleListModelMapper : Profile
    {
        public RoleListModelMapper()
        {
            CreateMap<Role, RoleListModel>();
        }
    }
}
