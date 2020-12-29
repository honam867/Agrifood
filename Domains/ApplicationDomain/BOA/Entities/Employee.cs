using ApplicationDomain.Core.Entities;
using ApplicationDomain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Employee : EntityBase<int>
    {
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
        public int AccountNumber { set; get; }
        public string Bank { get; set; }
        public string BankBranch { get; set; }
        public string PermissionGroup { get; set; }

    }
}