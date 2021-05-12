using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.MilkCoupons
{
    public class MilkCouponModelRq
    {
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public int EmployeeId { get; set; }
        public int StorageTankId { get; set; }
        public string Session { get; set; }
        public int MilkCollectionStationId { get; set; }
    }

    public class MilkCouponModelRqMapper : Profile
    {
        public MilkCouponModelRqMapper()
        {
            CreateMap<MilkCouponModelRq, MilkCoupon>();
            var mapers = CreateMap<MilkCoupon, MilkCouponModelRq>();
        }
    }
    public class MilkCouponModelRqValidator : AbstractValidator<MilkCouponModelRq>
    {
        public MilkCouponModelRqValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
        }
    }
}
