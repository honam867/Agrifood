using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Orders;
using AspNetCore.AutoGenerate;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderService(
            IOrderRepository orderRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _orderRepository = orderRepository;
            
        }

        public async Task<int> CreateOrderAsync(OrderModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Order>(model);
                entity.Code = await AutoGenerateCodeAsync();
                entity.CreateBy(issuer).UpdateBy(issuer);
                _orderRepository.Create(entity);
                return await _uow.SaveChangesAsync() == 1 ? entity.Id : 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                var entity = await _orderRepository.GetEntityByIdAsync(id);
                _orderRepository.Delete(entity);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrders().MapQueryTo<OrderModel>(_mapper).ToListAsync();
           
        }

        public async Task<OrderModel> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetOrderById(id).MapQueryTo<OrderModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateOrderAsync(int id, OrderModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _orderRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _orderRepository.Update(entity);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await _orderRepository.CheckCodeExistsAsync(code);
        }

        public async Task<IEnumerable<OrderModel>> GetOrderByFarmerIdAsync(int id)
        {
            return await _orderRepository.GetOrderByFarmerId(id).MapQueryTo<OrderModel>(_mapper).ToListAsync();
        }
        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateCode(10);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateCode(10));
        }
    }
}