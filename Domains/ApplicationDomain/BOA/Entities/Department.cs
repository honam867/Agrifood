using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Department : EntityBase<int>
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string Code { set; get; }
        public string PhoneNumber { set; get; }
        public string Remarks { set; get; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public string ShortName { get; set; }
    }
}
