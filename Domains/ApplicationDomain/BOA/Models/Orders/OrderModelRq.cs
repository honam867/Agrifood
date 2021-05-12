using ApplicationDomain.BOA.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.BOA.Models.Orders
{
    public class OrderModelRq
    {
        public string Code { get; set; }
        public int EmployeeId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public int FarmerId { get; set; }
    }

    public class OrderModelRqMapper : Profile
    {
        public OrderModelRqMapper()
        {
            CreateMap<OrderModelRq, Order>();
            var mapers = CreateMap<Order, OrderModelRq>();
        }
    }
}
