using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.ImportHistorys;
using ApplicationDomain.BOA.Models.MilkingSlips;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IImportHistoryService
    {
        Task<IEnumerable<ImportHistoryModel>> GetImportHistoryAsync();
        Task<ImportHistoryModel> GetImportHistoryByIdAsync(int id);
        Task<int> CreateImportHistoryAsync(ImportHistoryModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteImportHistoryAsync(int id);
        Task<bool> UpdateImportHistoryAsync(int id, ImportHistoryModelRq model, UserIdentity<int> issuer);
    }
}
