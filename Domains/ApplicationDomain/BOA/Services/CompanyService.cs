using ApplicationDomain.BOA.Entities;
using ApplicationDomain.BOA.IRepositories;
using ApplicationDomain.BOA.IServices;
using ApplicationDomain.BOA.Models.Companys;
using AspNetCore.Common.Dropbox;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.UnitOfWork;
using AutoMapper;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.Services
{
    public class CompanyService : ServiceBase, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IDropbox _dropbox;

        private readonly IFileManagerService _fileManagerService;
        public CompanyService(
            ICompanyRepository companyRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IDropbox dropbox,
            IFileManagerService fileManagerService
            ) : base(mapper, uow)
        {
            _companyRepository = companyRepository;
            _dropbox = dropbox;
            _fileManagerService = fileManagerService;
        }

        public async Task<int> CreateCompanyAsync(CompanyModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = _mapper.Map<Company>(model);
                entity.CreateBy(issuer).UpdateBy(issuer);
                _companyRepository.Create(entity);
                return await _uow.SaveChangesAsync() == 1 ? entity.Id : 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> CheckCodeExistsAsync(string code)
        {
            return await _companyRepository.CheckingCodeIsExist(code); ;
        }
        public async Task<bool> CheckCompanyExistsAsync()
        {
            var models = await GetCompanyAsync();
            return models.Any();
        }

        public async Task<bool> DeleteCompanyAsync(int id)
        {
            try
            {
                var entity = await _companyRepository.GetEntityByIdAsync(id);
                _companyRepository.Delete(entity);
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

        public async Task<IEnumerable<CompanyModel>> GetCompanyAsync()
        {
            return await _companyRepository.GetCompany().MapQueryTo<CompanyModel>(_mapper).ToListAsync();
        }

        public string GetCodeAsync()
        {
            return _companyRepository.GetCode();
        }

        public async Task<CompanyModel> GetCompanyByIdAsync(int id)
        {
            return await _companyRepository.GetCompanyById(id).MapQueryTo<CompanyModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCompanyAsync(int id, CompanyModelRq model, UserIdentity<int> issuer)
        {
            try
            {
                var entity = await _companyRepository.GetEntityByIdAsync(id);
                if (entity == null)
                {
                    return false;
                }
                _mapper.Map(model, entity);
                entity.UpdateBy(issuer);
                _companyRepository.Update(entity);
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

        public async Task<CompanyModel> GetCompany()
        {
            return await _companyRepository.GetCompany().MapQueryTo<CompanyModel>(_mapper).FirstOrDefaultAsync();
        }

        public async Task<bool> UploadLogoAsync(IFormFile file, UserIdentity<int> issuer)
        {
            try
            {
                var fileName = Path.GetFileName(file.FileName);
                var token = _dropbox.GetToken();
                using (DropboxClient dbx = new DropboxClient(token))
                {
                    var full = await dbx.Users.GetCurrentAccountAsync();
                    var extension = Path.GetExtension(file.FileName);
                    var imageName = Path.GetRandomFileName() + extension;
                    var imagePath = _fileManagerService.GetImageCompanyLogoFolderUrl() + imageName;
                    var fileStream = file.OpenReadStream();
                    var upload = await dbx.Files.UploadAsync(imagePath, WriteMode.Overwrite.Instance, false, null, false, null, true, fileStream);
                    var shared = await dbx.Sharing.CreateSharedLinkWithSettingsAsync(upload.PathDisplay);
                    string s = shared.Url;
                    s = s.Replace("?dl=0", "?dl=1");
                    if (s != null)
                    {
                        var entity = (await _companyRepository.GetEntity());
                        entity.LogoURL = s;
                        entity.UpdateBy(issuer);
                        _companyRepository.Update(entity);
                    }
                    if (await _uow.SaveChangesAsync() == 1)
                    {
                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
