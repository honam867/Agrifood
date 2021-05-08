using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.MilkCoupons
{
    public class MilkCouponModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public int EmployeeId { get; set; }
        public int StorageTankId { get; set; }
        public string Session { get; set; }
        public int MilkCollectionStationId { get; set; }

    }
    public class MilkCouponModelMapper : Profile
    {
        public MilkCouponModelMapper()
        {
            CreateMap<MilkCouponModel, MilkCoupon>();
            var mapers = CreateMap<MilkCoupon, MilkCouponModel>();
        }
    }
}
