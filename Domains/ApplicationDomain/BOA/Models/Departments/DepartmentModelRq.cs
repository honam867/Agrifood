using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Departments
{
    public class DepartmentModelRq
    {
        public int Id { get; set; }
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string Email { get; set; }
        public string Code { get; set; }  //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
        public string PhoneNumber { get; set; }
        public string Remarks { get; set; }
        public int BranchId { get; set; }
        public string ShortName { get; set; }
    }

    public class DepartmentRqMapper : Profile
    {
        public DepartmentRqMapper()
        {
            CreateMap<DepartmentModelRq, Department>();
            var mapers = CreateMap<Department, DepartmentModelRq>();
        }
    }
    public class BranchModelRqValidator : AbstractValidator<DepartmentModelRq>
    {
        public BranchModelRqValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(3);
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }
}
