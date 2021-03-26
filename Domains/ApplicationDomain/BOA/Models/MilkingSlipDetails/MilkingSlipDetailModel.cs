using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.MilkingSlipDetails
{
    public class MilkingSlipDetailModel
    {
        public int Id { get; set; }
        public int CowId { get; set; }
        public int MilkingSlipId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }

    }
    public class MilkingSlipDetailModelMapper : Profile
    {
        public MilkingSlipDetailModelMapper()
        {
            CreateMap<MilkingSlipDetailModel, MilkingSlipDetail>();
            var mapers = CreateMap<MilkingSlipDetail, MilkingSlipDetailModel>();
        }
    }
}
