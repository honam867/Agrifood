using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.MilkCollectionStations
{
    public class MilkCollectionStationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int WardId { get; set; }
        public int TypeOfMilkId { get; set; }

    }
    public class MilkCollectionStationModelMapper : Profile
    {
        public MilkCollectionStationModelMapper()
        {
            CreateMap<MilkCollectionStationModel, MilkCollectionStation>();
            var mapers = CreateMap<MilkCollectionStation, MilkCollectionStationModel>();
        }
    }
}
