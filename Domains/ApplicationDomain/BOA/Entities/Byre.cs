using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Byre : EntityBase<int>
    {
        public string Code { set; get; }
        public int QuantityCow { set; get; }
        public int FarmerId { set; get; }
        public Farmer Farmer { get; set; }
    }
}