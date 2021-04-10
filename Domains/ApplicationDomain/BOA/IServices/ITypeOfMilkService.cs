using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.TypeOfMilks;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface ITypeOfMilkService
    {
        Task<IEnumerable<TypeOfMilkModel>> GetTypeOfMilksAsync();
        Task<TypeOfMilkModel> GetTypeOfMilkByIdAsync(int id);
        Task<int> CreateTypeOfMilkAsync(TypeOfMilkModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteTypeOfMilkAsync(int id);
        Task<bool> UpdateTypeOfMilkAsync(int id, TypeOfMilkModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
