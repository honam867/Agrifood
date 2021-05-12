using ApplicationDomain.BOA.Entities;
using AutoMapper;
using System;

namespace ApplicationDomain.BOA.Models.Orders
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
    public class OrderModelMapper : Profile
    {
        public OrderModelMapper()
        {
            CreateMap<OrderModel, Order>();
            var mapers = CreateMap<Order, OrderModel>();
        }
    }
}
