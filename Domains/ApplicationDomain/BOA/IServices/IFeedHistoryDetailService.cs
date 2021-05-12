using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.FeedHistoryDetails;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IFeedHistoryDetailService
    {
        Task<IEnumerable<FeedHistoryDetailModel>> GetFeedHistoryDetailsAsync();
        Task<FeedHistoryDetailModel> GetFeedHistoryDetailByIdAsync(int id);
        Task<int> CreateFeedHistoryDetailAsync(FeedHistoryDetailModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteFeedHistoryDetailAsync(int id);
        Task<bool> UpdateFeedHistoryDetailAsync(int id, FeedHistoryDetailModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<IEnumerable<FeedHistoryDetailModel>> GetFeedHistoryDetailByFeedHistoryIdAsync(int id);
        Task<string> AutoGenerateCodeAsync(string code = "");
    }
}
