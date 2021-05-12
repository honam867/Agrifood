using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Order : EntityBase<int>
    {
        public string Code { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }
}
