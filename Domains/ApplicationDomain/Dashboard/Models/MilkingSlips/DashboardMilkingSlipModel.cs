using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.Dashboard.Models.MilkingSlips
{
    public class DashboardMilkingSlipModel
    {
        public DateTime Day { get; set; }
        public int Quantity { get; set; }
    }
}
