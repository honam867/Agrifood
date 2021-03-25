using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.MilkingSlips
{
    public class MilkingSlipModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public string Session { get; set; }

    }
    public class MilkingSlipModelMapper : Profile
    {
        public MilkingSlipModelMapper()
        {
            CreateMap<MilkingSlipModel, MilkingSlip>();
            var mapers = CreateMap<MilkingSlip, MilkingSlipModel>();
        }
    }
}
