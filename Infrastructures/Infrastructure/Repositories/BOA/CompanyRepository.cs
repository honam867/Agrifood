using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.BOA
{
    public class CompanyRepository : GenericRepository<Company, int>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> CheckingCodeIsExist(string code)
        {
            return this.dbSet.AnyAsync(r => r.Code == code);
        }
        public IQueryable GetCompany()
        {
            return dbSet;
        }

        public IQueryable GetCompanyById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetCompanyByCode(string code)
        {
            return dbSet.Where(r => r.Code == code);
        }

        public string GetCode()
        {
            return dbSet.First().Code;
        }
    }
}
