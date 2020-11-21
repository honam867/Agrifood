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
    public class DepartmentRepository : GenericRepository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await this.dbSet.AnyAsync(r => r.Code == code);
        }

        public IQueryable GetDepartment()
        {
            return this.dbSet.Include(u => u.Branch);
        }

        public IQueryable GetDepartmentByBranchId(int id)
        {
            return dbSet.Where(r => r.BranchId == id);
        }

        public IQueryable GetDepartmentById(int id)
        {
            return dbSet.Where(r => r.Id == id).Include(r=>r.Branch);
        }

    }
}
