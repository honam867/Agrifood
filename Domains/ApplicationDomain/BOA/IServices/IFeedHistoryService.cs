using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FeedHistorys;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IFeedHistoryService
    {
        Task<IEnumerable<FeedHistoryModel>> GetFeedHistorysAsync();
        Task<FeedHistoryModel> GetFeedHistoryByIdAsync(int id);
        Task<int> CreateFeedHistoryAsync(FeedHistoryModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteFeedHistoryAsync(int id);
        Task<bool> UpdateFeedHistoryAsync(int id, FeedHistoryModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<IEnumerable<FeedHistoryModel>> GetFeedHistoryByFarmerIdAsync(int id);
        Task<IEnumerable<FeedHistoryModel>> GetFeedHistoryByDateAsync(int day, int month, int year, int farmerId);
        Task<string> AutoGenerateCodeAsync(string code = "");
    }
}
