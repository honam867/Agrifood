using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Common.Azure
{
    public class AzureSettings
    {
        public string AzureConnectionString { get; set; }
        public string ImageFolderUrl { get; set; }
        public string LogoFolderUrl { get; set; }
        public string Environment { get; set; }
    }
}
