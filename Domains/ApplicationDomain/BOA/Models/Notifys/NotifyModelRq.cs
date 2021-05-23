using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Notifys
{
    public class NotifyModelRq
    {
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
    }

    public class NotifyModelRqMapper : Profile
    {
        public NotifyModelRqMapper()
        {
            CreateMap<NotifyModelRq, Notify>();
            var mapers = CreateMap<Notify, NotifyModelRq>();
        }
    }
}
