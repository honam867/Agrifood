using ApplicationDomain.Core.Entities;

namespace ApplicationDomain.BOA.Entities
{
    public class FoodSuggestion : EntityBase<int>
    {
        public int CowId { set; get; }
        public Cow Cow { set; get; }
        public string Content { set; get; }
    }
}
