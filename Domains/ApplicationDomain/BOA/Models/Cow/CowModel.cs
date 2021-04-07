using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Cows
{
    public class CowModel
    {
        public int Id { get; set; }
        public int ByreId { set; get; }
        public int? MotherId { set; get; }
        public int? FatherId { set; get; }
        public string Name { set; get; }
        public string Status { get; set; }
        public string Code { set; get; }
        public string TinhCode { get; set; }
        public DateTime Birthday { set; get; }
        public string Gender { set; get; }
        public DateTime WeaningDate { set; get; }
        public int FoodSuggestionId { set; get; }

    }
    public class CowModelMapper : Profile
    {
        public CowModelMapper()
        {
            CreateMap<CowModel, Cow>();
            var mapers = CreateMap<Cow, CowModel>();
        }
    }
}
