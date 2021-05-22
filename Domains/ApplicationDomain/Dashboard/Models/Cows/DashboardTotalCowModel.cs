using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.Dashboard.Models.Cows
{
    public class DashboardTotalCowModel
    {
        public int TongBo { get; set; }
        public int SinhSan { get; set; }
        public int BoThit { get; set; }
        public int Be { get; set; }
    }
}
