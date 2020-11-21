using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApplicationDomain.BOA.IServices
{
    public interface IFileManagerService
    {
        string GetDefaultFolderUrl();
        string GetImageAssetpartFolderUrl();
        string GetImageEmployeeAvatarFolderUrl();
        string GetImageFolderUrl();
        string GetImageCompanyLogoFolderUrl();
        string GetImageCRMTemplateFolderUrl();
        string GetImageCustomerTransfersFolderUrl();
        Task<string> UploadFileDefaultAsync(IFormFile formFile);
        Task<string> UploadFileAsync(IFormFile formFile, string folderUrl);
        string GetProductFileFolderUrl();
    }
}
