using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Warehouses
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public string FoodName { set; get; }
        public int WareHouseId { set; get; }
        public int Amount { set; get; }

    }
    public class WarehouseModelMapper : Profile
    {
        public WarehouseModelMapper()
        {
            CreateMap<WarehouseModel, Warehouse>();
            var mapers = CreateMap<Warehouse, WarehouseModel>();
        }
    }
}
