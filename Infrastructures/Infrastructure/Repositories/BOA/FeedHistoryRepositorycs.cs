using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BOA
{
    public class FeedHistoryRepository : GenericRepository<FeedHistory, int>, IFeedHistoryRepository
    {
        public FeedHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetFeedHistorys()
        {
            return this.dbSet;
        }

        public IQueryable GetFeedHistoryById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetFeedHistoryByFarmerId(int id)
        {
            var result = from fh in dbSet
                         join c in context.Set<Cow>() on fh.CowId equals c.Id
                         join b in context.Set<Byre>() on c.ByreId equals b.Id
                         where b.FarmerId == id
                         select fh;
            return result;
        }

        public IQueryable GetFeedHistoryByDate(int day, int month, int year, int farmerId)
        {
            var result = from fh in dbSet
                         join c in context.Set<Cow>() on fh.CowId equals c.Id
                         join b in context.Set<Byre>() on c.ByreId equals b.Id
                         where b.FarmerId == farmerId && fh.CreatedDate.Day == day && fh.CreatedDate.Month == month && fh.CreatedDate.Year == year
                         select fh;
            return result;
        }
    }
}
