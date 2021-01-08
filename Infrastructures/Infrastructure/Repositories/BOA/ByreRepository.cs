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
    public class ByreRepository : GenericRepository<Byre, int>, IByreRepository
    {
        public ByreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetByres()
        {
            return this.dbSet.Include(u => u.Breed);
        }

        public IQueryable GetByreById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }
    }
}
