using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.Dashboard.Models.MilkingSlips
{
    public class MilkingSlipDashboard
    {
        public DateTime Day { get; set; }
        public int Quantity { get; set; }
    }
}
