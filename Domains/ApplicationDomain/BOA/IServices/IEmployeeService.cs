using ApplicationDomain.BOA.Models.Employees;
using ApplicationDomain.BOA.Models.Farmers;
using AspNetCore.Common.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeModel>> GetEmployeeListAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task<int> CreateEmployeeAsync(EmployeeModelRq model, UserIdentity<int> issuer);
        Task<string> AutoGenerateCodeAsync(string code = "");
        Task<bool> UpdateEmployeeAsync(int id, EmployeeModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteEmployeeAsync(int id);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
