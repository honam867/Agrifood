using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order, int>
    {
        IQueryable GetOrders();
        IQueryable GetOrderById(int id);
        Task<bool> CheckCodeExistsAsync(string code);
        IQueryable GetOrderByFarmerId(int id);
    }
}
