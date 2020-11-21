using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Departments
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string Email { get; set; }
        public string Code { get; set; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
        public string Remarks { get; set; }
        public string PhoneNumber { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string ShortName { get; set; }
    }

    public class DepartmentModelMapper : Profile
    {
        public DepartmentModelMapper()
        {
            CreateMap<Department, DepartmentModel>();
            var mapers = CreateMap<Department, DepartmentModel>();
            mapers.ForMember(d => d.BranchName, opt => opt.MapFrom(s => s.Branch.Name));
        }
    }
}
