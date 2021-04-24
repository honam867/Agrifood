using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.StorageTanks
{
    public class StorageTankModelRq
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string TypeMilk { get; set; }
        public int Quantity { get; set; }
        public int MilkCollectionStationId { get; set; }
    }

    public class StorageTankModelRqMapper : Profile
    {
        public StorageTankModelRqMapper()
        {
            CreateMap<StorageTankModelRq, StorageTank>();
            var mapers = CreateMap<StorageTank, StorageTankModelRq>();
        }
    }
    /*public class StorageTankModelRqValidator : AbstractValidator<StorageTankModelRq>
    {
        public StorageTankModelRqValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }*/
}
