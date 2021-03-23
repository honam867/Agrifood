using ApplicationDomain.Core.Entities;
using ApplicationDomain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class MilkCoupon : EntityBase<int>
    {
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
        public string ScaleCode { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StorageTankCode { get; set; }
        public string Session { get; set; }
        public int MilkCollectionStationId { get; set; }
        public MilkCollectionStation MilkCollectionStation { get; set; }

    }
}