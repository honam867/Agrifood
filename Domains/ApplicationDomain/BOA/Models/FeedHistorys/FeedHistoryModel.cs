using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.FeedHistorys
{
    public class FeedHistoryModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CowId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
    public class FeedHistoryModelMapper : Profile
    {
        public FeedHistoryModelMapper()
        {
            CreateMap<FeedHistoryModel, FeedHistory>();
            var mapers = CreateMap<FeedHistory, FeedHistoryModel>();
        }
    }
}
