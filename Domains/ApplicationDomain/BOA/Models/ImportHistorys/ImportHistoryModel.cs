using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.ImportHistorys
{
    public class ImportHistoryModel
    {
        public int Id { get; set; }
        public string FoodName { set; get; }
        public int WareHouseId { set; get; }
        public int Amount { set; get; }

    }
    public class ImportHistoryModelMapper : Profile
    {
        public ImportHistoryModelMapper()
        {
            CreateMap<ImportHistoryModel, ImportHistory>();
            var mapers = CreateMap<ImportHistory, ImportHistoryModel>();
        }
    }
}
