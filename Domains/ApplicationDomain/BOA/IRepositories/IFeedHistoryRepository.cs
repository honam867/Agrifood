using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.Models.FeedHistorys;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IFeedHistoryRepository : IGenericRepository<FeedHistory, int>
    {
        IQueryable GetFeedHistorys();
        IQueryable GetFeedHistoryById(int id);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<IEnumerable<FeedHistoryByreModel>> GetFeedHistoryByFarmerId(int id);
        IQueryable GetFeedHistoryByDate(int day, int month, int year, int farmerId);
    }
}
