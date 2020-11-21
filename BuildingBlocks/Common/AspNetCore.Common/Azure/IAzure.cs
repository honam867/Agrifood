using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Common.Azure
{
    public interface IAzure
    {
        string GetAzureConnectionString();
        string GetImageFolerUrl();
        string GetLogoFolderUrl();
        string GetFileNameByUrl(string url);
        string GetEnvironment();
    }
}
