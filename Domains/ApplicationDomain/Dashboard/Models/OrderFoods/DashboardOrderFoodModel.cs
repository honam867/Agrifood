using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.Dashboard.Models.MilkingSlips
{
    public class DashboardOrderFoodModel
    {
        public int Quantity { get; set; }
        public string FoodName { get; set; }
        public string FoodType { get; set; }
    }
}
