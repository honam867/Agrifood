using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.Departments;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetDepartmentsAsync();
        Task<DepartmentModel> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<DepartmentModel>> GetDepartMentByBranchIdAsync(int id);
        Task<int> CreateDepartmentAsync(DepartmentModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteDepartmentAsync(int id);
        Task<bool> UpdateDepartmentAsync(int id, DepartmentModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
