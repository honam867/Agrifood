using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.MilkCouponDetails
{
    public class MilkCouponDetailModel
    {
        public int Id { get; set; }
        public int? MilkCouponId { get; set; }
        public int Quantity { get; set; }
        public int TypeMilk { get; set; }

    }
    public class MilkCouponDetailModelMapper : Profile
    {
        public MilkCouponDetailModelMapper()
        {
            CreateMap<MilkCouponDetailModel, MilkCouponDetail>();
            var mapers = CreateMap<MilkCouponDetail, MilkCouponDetailModel>();
        }
    }
}
