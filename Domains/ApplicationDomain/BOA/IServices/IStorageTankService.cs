using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.StorageTanks;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IStorageTankService
    {
        Task<IEnumerable<StorageTankModel>> GetStorageTankAsync();
        Task<StorageTankModel> GetStorageTankByIdAsync(int id);
        Task<int> CreateStorageTankAsync(StorageTankModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteStorageTankAsync(int id);
        Task<bool> UpdateStorageTankAsync(int id, StorageTankModelRq model, UserIdentity<int> issuer);
    }
}
