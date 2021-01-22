using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.Models.Employees;
using ApplicationDomain.Identity.Entities;
using AutoMapper;
using FluentValidation;
using System;

namespace ApplicationDomain.BOA.Models.Employees
{
    public class EmployeeModelRq
    {
        public int Id { get; set; }
        public int? UserId { set; get; }
        public string Code { get; set; }
        public string Name { set; get; }
        public string FullName { set; get; }
        public string UserName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Address { set; get; }
        public DateTime Birthday { set; get; }
        public string IdentificationNo { set; get; }
        public DateTime IssuedOn { set; get; }
        public string IssuedBy { set; get; }
        public string AccountNumber { set; get; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string PermissionGroup { get; set; }
    }
}

public class EmployeeModelRqMapper : Profile
{
    public EmployeeModelRqMapper()
    {
        CreateMap<EmployeeModelRq, Employee>();
        var mapers = CreateMap<Employee, EmployeeModelRq>();
    }
}

public class EmployeeModelRqValidator : AbstractValidator<EmployeeModelRq>
{
    public EmployeeModelRqValidator()
    {
    }
}

