using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Notifys;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface INotifyService
    {
        Task<IEnumerable<NotifyModel>> GetNotifysAsync();
        Task<NotifyModel> GetNotifyByIdAsync(int id);
        Task<int> CreateNotifyAsync(NotifyModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteNotifyAsync(int id);
        Task<bool> UpdateNotifyAsync(int id, NotifyModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<IEnumerable<NotifyModel>> GetNotifyByFarmerIdAsync(int id);
        Task<IEnumerable<NotifyModel>> GetNotifyByEmployeeIdAsync(int id);
    }
}
