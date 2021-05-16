using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Notifys
{
    public class NotifyModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int FarmerId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
    public class NotifyModelMapper : Profile
    {
        public NotifyModelMapper()
        {
            CreateMap<NotifyModel, Notify>();
            var mapers = CreateMap<Notify, NotifyModel>();
        }
    }
}
