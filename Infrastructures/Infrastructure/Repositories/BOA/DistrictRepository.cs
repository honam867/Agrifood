using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BOA
{
    public class DistrictRepository : GenericRepository<District, int>, IDistrictRepository
    {
        public DistrictRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public IQueryable GetDistricts()
        {
            return dbSet.OrderBy(r => r.Name);
        }

        public IQueryable GetDistrictById(int id)
        {
            return dbSet.Where(d => d.Id == id).Include(d => d.Province);
        }

        public IQueryable GetDistricByPrivinceId(int id)
        {
            return dbSet.Where(d => d.ProvinceId == id);
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await dbSet.AnyAsync(r => r.Code == code);
        }
    }
}
