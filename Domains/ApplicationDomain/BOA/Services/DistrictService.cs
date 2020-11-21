using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models;
using AspNetCore.AutoGenerate;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.Services
{
    public class DistrictService : ServiceBase, IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly IProvinceRepository _provinceRepository;
        public DistrictService(
            IDistrictRepository districtRepository,
            IProvinceRepository provinceRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _districtRepository = districtRepository;
            _provinceRepository = provinceRepository;
        }

        public async Task<IEnumerable<DistrictModel>> GetDistrictsAsync()
        {
            return await _districtRepository.GetDistricts().MapQueryTo<DistrictModel>(_mapper).ToListAsync();
        }

        public async Task<DistrictModel> GetDistrictByIdAsync(int id)
        {
            return await _districtRepository.GetDistrictById(id).MapQueryTo<DistrictModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<int> CreateDistrictAsync(DistrictModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var district = _mapper.Map<District>(model);
                district.CreateBy(issuer).UpdateBy(issuer);
                _districtRepository.Create(district);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return district.Id;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       public async Task<IEnumerable<DistrictModel>> GetDistricByPrivinceIdAsync(int id)
        {
            return await _districtRepository.GetDistricByPrivinceId(id).MapQueryTo<DistrictModel>(_mapper).ToListAsync();
        }

        public async Task<bool> UpdateDistrictAsync(int id, DistrictModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var district = await _districtRepository.GetEntityByIdAsync(id);
                if (district == null)
                {
                    return false;
                }
                _mapper.Map(model, district);
                district.UpdateBy(issuer);
                _districtRepository.Update(district);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteDistrictAsync(int id)
        {
            try
            {
                var district = await _districtRepository.GetEntityByIdAsync(id);
                _districtRepository.Delete(district);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<List<APIDistrictModel>> GetDistrictFromAPIAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<List<APIDistrictModel>>(await response.Content.ReadAsStringAsync());
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> ImportDistrictFromAPIAsync(UserIdentity<int> issuer)
        {
            try
            {
                var provinces = await _provinceRepository.GetProvinces().MapQueryTo<ProvinceModel>(_mapper).ToListAsync();
                foreach (ProvinceModel provinceModel in provinces)
                {
                    // UPDATE GET FROM APPSETTING 
                    var url = "https://thongtindoanhnghiep.co/api/city/" + provinceModel.Code + "/district";
                    var APIItems = await GetDistrictFromAPIAsync(url);
                    if (APIItems != null)
                    {
                        foreach (APIDistrictModel item in APIItems)
                        {
                            var district = new District()
                            {
                                Name = item.Title,
                                Code = item.Id.ToString(),
                                Type = item.Type,
                                ProvinceId = provinceModel.Id
                            };
                            district.CreateBy(issuer).UpdateBy(issuer);
                            _districtRepository.Create(district);
                        }
                    }
                 
                }
                if (await _uow.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await _districtRepository.CheckCodeExistsAsync(code);
        }

        public async Task<string> AutoGenerateCodeAsync(string code = "")
        {
            if (code.Equals(""))
                code = AutoGenerate.AutoGenerateCode(3);
            if (!await CheckCodeExistsAsync(code))
                return code;
            return await AutoGenerateCodeAsync(AutoGenerate.AutoGenerateCode(3));
        }
    }
}
