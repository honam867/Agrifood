using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Notify : EntityBase<int>
    {
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
    }
}