using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Orders;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(int id);
        Task<int> CreateOrderAsync(OrderModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> UpdateOrderAsync(int id, OrderModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<IEnumerable<OrderModel>> GetOrderByFarmerIdAsync(int id);
        Task<bool> UpdateCodeAsync();
    }
}
