using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.MilkCouponDetails
{
    public class MilkCouponDetailModelRq
    {
        public int CowId { get; set; }
        public int MilkingSlipId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }

    public class MilkCouponDetailModelRqMapper : Profile
    {
        public MilkCouponDetailModelRqMapper()
        {
            CreateMap<MilkCouponDetailModelRq, MilkCouponDetail>();
            var mapers = CreateMap<MilkCouponDetail, MilkCouponDetailModelRq>();
        }
    }
    public class MilkCouponDetailModelRqValidator : AbstractValidator<MilkCouponDetailModelRq>
    {
        public MilkCouponDetailModelRqValidator()
        {
            
        }
    }
}
