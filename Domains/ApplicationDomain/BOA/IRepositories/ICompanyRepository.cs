using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface ICompanyRepository : IGenericRepository<Company, int>
    {
        IQueryable GetCompany();
        IQueryable GetCompanyById(int id);
        string GetCode();
        IQueryable GetCompanyByCode(string code);
        Task<bool> CheckingCodeIsExist(string code);
    }
}
