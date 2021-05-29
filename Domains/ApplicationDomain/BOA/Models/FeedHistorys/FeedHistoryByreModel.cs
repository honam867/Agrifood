using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.FeedHistorys
{
    public class FeedHistoryByreModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CowId { get; set; }
        public string CowName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string ByreName { get; set; }
    }
}
