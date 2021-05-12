using ApplicationDomain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Entities
{
    public class FeedHistoryDetail : EntityBase<int>
    {
        public string Code { get; set; }
        public int FeedHistoryId { get; set; }
        public FeedHistory FeedHistory { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }


    }
}
