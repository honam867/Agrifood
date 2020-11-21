using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Common.Azure
{
    public class Azure : IAzure
    {
        private readonly AzureSettings _azureSettings;
        public Azure(
            IOptions<AzureSettings> azureSettings
            )
        {
            _azureSettings = azureSettings.Value;
        }

        public string GetAzureConnectionString()
        {
            return _azureSettings.AzureConnectionString;
        }

        public string GetEnvironment()
        {
            return _azureSettings.Environment;
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

        public string GetImageFolerUrl()
        {
            return _azureSettings.ImageFolderUrl;
        }

        public string GetLogoFolderUrl()
        {
            return _azureSettings.LogoFolderUrl;
        }
    }
}
