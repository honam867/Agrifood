using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class Province : EntityBase<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
    }
}
