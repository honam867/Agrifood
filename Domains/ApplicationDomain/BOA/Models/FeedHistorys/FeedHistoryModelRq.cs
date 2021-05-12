using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.FeedHistorys
{
    public class FeedHistoryModelRq
    {
        public string Code { get; set; }
        public int CowId { get; set; }
    }

    public class FeedHistoryModelRqMapper : Profile
    {
        public FeedHistoryModelRqMapper()
        {
            CreateMap<FeedHistoryModelRq, FeedHistory>();
            var mapers = CreateMap<FeedHistory, FeedHistoryModelRq>();
        }
    }
}
