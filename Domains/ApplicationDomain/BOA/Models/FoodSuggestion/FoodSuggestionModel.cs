using ApplicationDomain.BOA.Entities;
using AutoMapper;


namespace ApplicationDomain.BOA.Models.FoodSuggestions
{
    public class FoodSuggestionModel
    {
        public int Id { get; set; }
        public int CowId { set; get; }
        public string Content { set; get; }
        public int FoodId { get; set; }
        public Cow Cow { get; set; }
    }
    public class FoodSuggestionModelMapper : Profile
    {
        public FoodSuggestionModelMapper()
        {
            CreateMap<FoodSuggestionModel, FoodSuggestion>();
            var mapers = CreateMap<FoodSuggestion, FoodSuggestionModel>();
        }
    }
}
