using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Warehouses
{
    public class WarehouseModelRq
    {
        public string FoodName { set; get; }
        public int WareHouseId { set; get; }
        public int Amount { set; get; }
    }

    public class WarehouseModelRqMapper : Profile
    {
        public WarehouseModelRqMapper()
        {
            CreateMap<WarehouseModelRq, Warehouse>();
            var mapers = CreateMap<Warehouse, WarehouseModelRq>();
        }
    }
    /*public class WarehouseModelRqValidator : AbstractValidator<WarehouseModelRq>
    {
        public WarehouseModelRqValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }*/
}
