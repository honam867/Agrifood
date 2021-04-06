using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class ImportHistory : EntityBase<int>
    {
        public string FoodName { set; get; }
        public int WareHouseId { set; get; }
        public Warehouse WareHouse { set; get; }
        public int Amount { set; get; }
    }
}