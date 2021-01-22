using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.CMMS
{
    public class FarmerRepository : GenericRepository<Farmer, int>, IFarmerRepository
    {
        public FarmerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetFarmers()
        {
            IQueryable rs = this.dbSet
                .Include(r => r.User);
            return rs;
        }

        public IQueryable GetFarmerById(int id)
        {
            IQueryable rs = this.dbSet
                .Where(r => r.Id == id);
            return rs;
        }
        public async Task<string> GetCodeByIdAsync(int id)
        {
            var model = await this.dbSet.FirstOrDefaultAsync(r => r.Id == id);
            return model != null ? model.Code : null;
        }
        public IQueryable GetFarmerByUser(int id)
        {
            return dbSet.Where(d => d.UserId == id);
        }
    }
}
