﻿using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.Dashboard.Models.Cows
{
    public class CowTotalModel
    {
        public int TongBo { get; set; }
        public int SinhSan { get; set; }
        public int BoThit { get; set; }
    }
}