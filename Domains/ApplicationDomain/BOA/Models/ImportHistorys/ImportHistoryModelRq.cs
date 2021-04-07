using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.ImportHistorys
{
    public class ImportHistoryModelRq
    {
        public string FoodName { set; get; }
        public int WareHouseId { set; get; }
        public int Amount { set; get; }
    }

    public class ImportHistoryModelRqMapper : Profile
    {
        public ImportHistoryModelRqMapper()
        {
            CreateMap<ImportHistoryModelRq, ImportHistory>();
            var mapers = CreateMap<ImportHistory, ImportHistoryModelRq>();
        }
    }
    /*public class ImportHistoryModelRqValidator : AbstractValidator<ImportHistoryModelRq>
    {
        public ImportHistoryModelRqValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Code).Length(3);
        }
    }*/
}
