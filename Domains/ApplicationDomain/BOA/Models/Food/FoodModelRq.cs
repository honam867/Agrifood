using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Foods
{
    public class FoodModelRq
    {
        public string Name { get; set; } //NOT NULL, LENGTH > 5, UPPER CASE
        public string Code { set; get; } //NOT NULL, LENGTH = 3, UPPER CASE, UNIQUE
        public int Provinceid { set; get; }
        public string Type { set; get; }
    }

    public class FoodModelRqMapper : Profile
    {
        public FoodModelRqMapper()
        {
            CreateMap<FoodModelRq, Food>();
            var mapers = CreateMap<Food, FoodModelRq>();
        }
    }
}
