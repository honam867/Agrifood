using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class FeedHistory : EntityBase<int>
    {
        public string Code { get; set; }
        public int CowId { get; set; }
        public Cow Cow { get; set; }

    }
}
