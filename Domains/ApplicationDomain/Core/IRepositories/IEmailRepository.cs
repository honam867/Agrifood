using ApplicationDomain.Core.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.Core.IRepositories
{
    public interface IEmailRepository: IGenericRepository<EmailTemplate, int>
    {
        IQueryable GetEmailTemplate();
        IQueryable GetEmailTemplateById(int id);
        IQueryable GetEmailTemplateByName(string name);
        Task<EmailTemplate> GetEmailTemplateByNameAsync(string name);
        Task<bool> CheckNameExistsAsync(string name);
    }
}
