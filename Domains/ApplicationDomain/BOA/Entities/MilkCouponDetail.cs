using ApplicationDomain.Core.Entities;
using ApplicationDomain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class MilkCouponDetail : EntityBase<int>
    {
        public int? MilkCouponId { get; set; }
        public MilkCoupon MilkCoupon { get; set; }
        public int Quantity { get; set; }
        public int TypeMilk { get; set; }
    }
}