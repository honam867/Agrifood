﻿using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.Dashboard.Models.MilkCoupons
{
    public class MilkCouponDashboardModel
    {
        public DateTime Day { get; set; }
        public int Quantity { get; set; }
    }
}
