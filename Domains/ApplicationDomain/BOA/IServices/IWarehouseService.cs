using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Warehouses;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseModel>> GetWarehouseAsync();
        Task<WarehouseModel> GetWarehouseByIdAsync(int id);
        Task<int> CreateWarehouseAsync(WarehouseModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteWarehouseAsync(int id);
        Task<bool> UpdateWarehouseAsync(int id, WarehouseModelRq model, UserIdentity<int> issuer);
    }
}
