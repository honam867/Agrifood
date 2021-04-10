using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class TypeOfMilk : EntityBase<int>
    {
        public string Code { set; get; }
        public string Name { set; get; }
    }
}