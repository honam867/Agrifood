using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.FoodSuggestions
{
    public class FoodSuggestionModelRq
    {
        public int CowId { set; get; }
        public string Content { set; get; }
    }

    public class FoodSuggestionModelRqMapper : Profile
    {
        public FoodSuggestionModelRqMapper()
        {
            CreateMap<FoodSuggestionModelRq, FoodSuggestion>();
            var mapers = CreateMap<FoodSuggestion, FoodSuggestionModelRq>();
        }
    }
    public class FoodSuggestionModelRqValidator : AbstractValidator<FoodSuggestionModelRq>
    {
        public FoodSuggestionModelRqValidator()
        {
           
        }
    }
}
