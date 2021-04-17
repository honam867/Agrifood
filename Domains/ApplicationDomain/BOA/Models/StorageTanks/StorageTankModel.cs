using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.StorageTanks
{
    public class StorageTankModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string TypeMilk { get; set; }
        public int Quantity { get; set; }
        public int MilkCollectionStationId { get; set; }

    }
    public class StorageTankModelMapper : Profile
    {
        public StorageTankModelMapper()
        {
            CreateMap<StorageTankModel, StorageTank>();
            var mapers = CreateMap<StorageTank, StorageTankModel>();
        }
    }
}
