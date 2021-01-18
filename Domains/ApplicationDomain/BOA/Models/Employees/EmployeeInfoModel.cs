using ApplicationDomain.BOA.Entities;
using ApplicationDomain.Identity.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Farmers
{
    public class EmployeeInfoModel
    {
        public int id { get; set; }
        public int? userId { set; get; }
        public string code { get; set; }
        public string name { set; get; }
        public string fullName { set; get; }
        public string userName { set; get; }
        public string email { set; get; }
        public string phoneNumber { set; get; }
        public string address { set; get; }
        public DateTime birthday { set; get; }
        public string identificationNo { set; get; }
        public DateTime issuedOn { set; get; }
        public string issuedBy { set; get; }
        public string accountNumber { set; get; }
        public string userUserName { get; set; }
        public string bank { get; set; }
        public string bankBranch { get; set; }
        public string permissionGroup { get; set; }
    }

    public class EmployeeInfoModelMapper : Profile
    {
        public EmployeeInfoModelMapper()
        {
            CreateMap<Employee, EmployeeInfoModel>();
        }
    }
}
