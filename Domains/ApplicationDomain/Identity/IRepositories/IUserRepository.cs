

using ApplicationDomain.Identity.Entities;
using AspNetCore.UnitOfWork;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.Identity.IRepositories
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        IQueryable GetUsers();
        IQueryable<User> GetManagerUsers();
        IQueryable<User> GetDirectorUsers();
        IQueryable<User> GetEmployeeUsers();
        string GetNetResetCodeByResetCode(string code);
        Task<User> GetUserByPhoneNumber(string phoneNumber);
    }
}
