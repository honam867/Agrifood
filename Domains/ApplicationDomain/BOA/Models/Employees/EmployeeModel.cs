using ApplicationDomain.BOA.Entities;
using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Farmers
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public int UserId { set; get; }
        public User User { get; set; }
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

    public class EmployeeModelMapper : Profile
    {
        public EmployeeModelMapper()
        {
            CreateMap<Employee, EmployeeModel>();
        }
    }
}
