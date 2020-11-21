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
    public class ProvinceService : ServiceBase, IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;
        public ProvinceService(
            IProvinceRepository provinceRepository,
            IMapper mapper,
            IUnitOfWork uow
            ) : base(mapper, uow)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<IEnumerable<ProvinceModel>> GetListProvincesAsync()
        {
            return await _provinceRepository.GetProvinces().MapQueryTo<ProvinceModel>(_mapper).ToListAsync();
        }

        public async Task<ProvinceModel> GetProvinceByIdAsync(int id)
        {
            return await _provinceRepository.GetProvinceById(id).MapQueryTo<ProvinceModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<int> CreateProvinceAsync(ProvinceModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var province = _mapper.Map<Province>(model);
                province.CreateBy(issuer).UpdateBy(issuer);
                _provinceRepository.Create(province);
                if (await _uow.SaveChangesAsync() == 1)
                {
                    return province.Id;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateProvinceAsync(int id, ProvinceModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var province = await _provinceRepository.GetEntityByIdAsync(id);
                if (province == null)
                {
                    throw new Exception("Not Found");
                }
                _mapper.Map(model, province);
                _provinceRepository.Update(province);
                province.UpdateBy(issuer);
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

        public async Task<bool> DeleteProvinceAsync(int id)
        {
            try
            {
                var province = await _provinceRepository.GetEntityByIdAsync(id);
                _provinceRepository.Delete(province);
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

        private async Task<APIListProvinceModel> GetAPIAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<APIListProvinceModel>(await response.Content.ReadAsStringAsync());
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<bool> ImportProvinceFromAPIAsync(UserIdentity<int> issuer)
        {
            // UPDATE GET FROM APPSETTING
            string url = "https://thongtindoanhnghiep.co/api/city";
            try
            {
                var APIListItem = await GetAPIAsync(url);
                foreach (APIProvinceModel m in APIListItem.LtsItem)
                {
                    var province = new Province()
                    {
                        Name = m.Title,
                        Code = m.Id.ToString(),
                        Type = m.Type
                    };
                    province.CreateBy(issuer).UpdateBy(issuer);
                    _provinceRepository.Create(province);
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
            return await _provinceRepository.CheckCodeExistsAsync(code);
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
