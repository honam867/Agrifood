using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BOA
{
    public class ProvinceRepository : GenericRepository<Province, int>, IProvinceRepository
    {
        public ProvinceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public IQueryable GetProvinces()
        {
            return dbSet.OrderBy(r => r.Name);
        }

        public IQueryable GetProvinceById(int id)
        {
            return dbSet.Where(p => p.Id == id);
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await dbSet.AnyAsync(r=>r.Code==code);
        }
    }
}
