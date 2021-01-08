using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Cows
{
    public class CowModel
    {
        public int Id { get; set; }
        public int CowId { set; get; }
        public Cow Cow { set; get; }
        public int MotherId { set; get; }
        public int FatherId { set; get; }
        public string Name { set; get; }
        public string QRCode { set; get; }
        public string Code { set; get; }
        public DateTime Birthday { set; get; }
        public int AgeNumber { set; get; }
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
