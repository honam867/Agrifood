using Microsoft.Extensions.Options;

namespace AspNetCore.Common.Dropbox
{
    public class Dropbox : IDropbox
    {
        private readonly DropboxSettings _dropboxSettings;
        public Dropbox(
           IOptions<DropboxSettings> dropboxSettings
           )
        {
            _dropboxSettings = dropboxSettings.Value;
        }

        public string GetFileNameByUrl(string url)
        {
            int nameLength = 0;
            char[] arrays = url.ToCharArray();
            for (int i = url.Length - 1; i > 0; i--)
            {
                if (arrays[i].ToString() != "/")
                {
                    nameLength++;
                }
                else
                {
                    break;
                }
            }
            return url.Substring(url.Length - nameLength);
        }

        public string GetToken()
        {
            return _dropboxSettings.Token;
        }

        public string GetLv1CompanyCodeUrl()
        {
            return _dropboxSettings.Lv1CompanyCodeUrl;
        }
        public string GetLv2EnvironmentUrl()
        {
            return _dropboxSettings.Lv2EnvironmentUrl;
        }

        public string GetLv3AssetImageUrl()
        {
            return _dropboxSettings.Lv3AssetImageUrl;
        }

        public string GetLv3AssetFileUrl()
        {
            return _dropboxSettings.Lv3AssetFileUrl;
        }

        public string GetLv3AssetDefaultUrl()
        {
            return _dropboxSettings.Lv3AssetDefaultUrl;
        }

        public string GetLv4CompanyUrl()
        {
            return _dropboxSettings.Lv4CompanyUrl;
        }

        public string GetLv4EmployeeUrl()
        {
            return _dropboxSettings.Lv4EmployeeUrl;
        }

        public string GetLv4CustomerUrl()
        {
            return _dropboxSettings.Lv4CustomerUrl;
        }

        public string GetLv4AssetpartUrl()
        {
            return _dropboxSettings.Lv4AssetpartUrl;
        }

        public string GetLv4CRMTemplateUrl()
        {
            return _dropboxSettings.Lv4CRMTemplateUrl;
        }

        public string GetLv4ProductUrl()
        {
            return _dropboxSettings.Lv4ProductUrl;
        }

        public string GetLv5DrawingUrl()
        {
            return _dropboxSettings.Lv5DrawingUrl;
        }

        public string GetLv5LogoUrl()
        {
            return _dropboxSettings.Lv5LogoUrl;
        }

        public string GetLv5AvatarUrl()
        {
            return _dropboxSettings.Lv5AvatarUrl;
        } 
        
        public string GetLv5TimeSheetUrl()
        {
            return _dropboxSettings.Lv5TimeSheetUrl;
        }

        public string GetLv5TransfersUrl()
        {
            return _dropboxSettings.Lv5TransfersUrl;
        }
    }
}
