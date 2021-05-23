using ApplicationDomain.BOA.Models;
using ApplicationDomain.BOA.Models.MilkCollectionStations;
using AspNetCore.Common.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IMilkCollectionStationService
    {
        Task<IEnumerable<MilkCollectionStationModel>> GetMilkCollectionStationAsync();
        Task<MilkCollectionStationModel> GetMilkCollectionStationByIdAsync(int id);
        Task<int> CreateMilkCollectionStationAsync(MilkCollectionStationModelRq model, UserIdentity<int> issuer);
        Task<bool> DeleteMilkCollectionStationAsync(int id);
        Task<bool> UpdateMilkCollectionStationAsync(int id, MilkCollectionStationModelRq model, UserIdentity<int> issuer);
        Task<bool> CheckCodeExistsAsync(string code);
        Task<string> AutoGenerateCodeAsync(string code = "");
        Task<bool> UpdateStatusAsync(int id, UserIdentity<int> issuer);
    }
}
