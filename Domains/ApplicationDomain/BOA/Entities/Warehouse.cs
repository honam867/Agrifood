using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Warehouse : EntityBase<int>
    {
        public string FoodName { set; get; }
        public string Code { set; get; }
        public int Amount { set; get; }
    }
}