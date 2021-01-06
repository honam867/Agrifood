using ApplicationDomain.BOA.Entities;
using AspNetCore.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IRepositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee, int>
    {
        Task<bool> CheckCodeExistsAsync(string code);
        IQueryable GetEmployees();
        IQueryable GetEmployeeById(int id);
    }
}
