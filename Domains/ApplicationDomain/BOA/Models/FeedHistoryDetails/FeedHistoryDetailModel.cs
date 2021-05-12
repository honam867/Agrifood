using ApplicationDomain.BOA.Entities;
using AutoMapper;


namespace ApplicationDomain.BOA.Models.FeedHistoryDetails
{
    public class FeedHistoryDetailModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int FeedHistoryId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public string FoodType { get; set; }
        public string FoodName { get; set; }
    }
    public class FeedHistoryDetailModelMapper : Profile
    {
        public FeedHistoryDetailModelMapper()
        {
            CreateMap<FeedHistoryDetailModel, FeedHistoryDetail>();
            var mapers = CreateMap<FeedHistoryDetail, FeedHistoryDetailModel>();
        }
    }
}
