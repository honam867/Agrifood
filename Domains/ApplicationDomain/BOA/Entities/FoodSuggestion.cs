using ApplicationDomain.Core.Entities;

namespace ApplicationDomain.BOA.Entities
{
    public class FoodSuggestion : EntityBase<int>
    {
        public string Code { get; set; }
        public string Content { set; get; }
        public int FoodId { get; set; }
        public Food Food { get; set; }

    }
}
