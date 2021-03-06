using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class MilkingSlip : EntityBase<int>
    {
        public string Code { get; set; }
        public int FarmerId { get;set;}
        public Farmer Farmer { get; set; }
        public string Session { get; set; }
    }
}