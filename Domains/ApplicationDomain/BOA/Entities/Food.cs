using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Food : EntityBase<int>
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string Type { set; get; }
        public int ProvinceId { set; get; }
        public Province Province { set; get; }
    }
}