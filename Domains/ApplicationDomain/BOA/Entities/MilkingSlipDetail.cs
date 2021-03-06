using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class MilkingSlipDetail : EntityBase<int>
    {
        public int? CowId { get; set; }
        public Cow Cow { get; set; }
        public int? MilkingSlipId { get;set;}
        public MilkingSlip MilkingSlip { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}