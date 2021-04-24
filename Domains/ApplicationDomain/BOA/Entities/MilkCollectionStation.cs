using ApplicationDomain.Core.Entities;
using ApplicationDomain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class MilkCollectionStation : EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }

    }
}