using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.FeedHistoryDetails
{
    public class FeedHistoryDetailModelRq
    {
        public string Code { get; set; }
        public int FeedHistoryId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
    }

    public class FeedHistoryDetailModelRqMapper : Profile
    {
        public FeedHistoryDetailModelRqMapper()
        {
            CreateMap<FeedHistoryDetailModelRq, FeedHistoryDetail>();
            var mapers = CreateMap<FeedHistoryDetail, FeedHistoryDetailModelRq>();
        }
    }
}
