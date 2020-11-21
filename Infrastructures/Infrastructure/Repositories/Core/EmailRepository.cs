using ApplicationDomain.Core.Entities;
using ApplicationDomain.Core.IRepositories;
using AspNetCore.UnitOfWork.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Core
{
    public class EmailRepository: GenericRepository<EmailTemplate, int>, IEmailRepository
    {
        public EmailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable GetEmailTemplate()
        {
            return dbSet;
        }

        public IQueryable GetEmailTemplateById(int id)
        {
            return dbSet.Where(r => r.Id == id);
        }

        public IQueryable GetEmailTemplateByName(string name)
        {
            return dbSet.Where(r => r.Name == name);
        }

        public async Task<EmailTemplate> GetEmailTemplateByNameAsync(string name)
        {
            try
            {
                var result = await dbSet.FirstOrDefaultAsync(r => r.Name == name);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public async Task<bool> CheckNameExistsAsync(string name)
        {
            return await dbSet.AnyAsync(r => r.Name == name);
        }
    }
}
