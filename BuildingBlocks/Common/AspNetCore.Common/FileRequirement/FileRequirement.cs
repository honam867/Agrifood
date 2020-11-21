using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AspNetCore.Common.FileRequirement
{
    public class FileRequirement : IFileRequirement
    {
        private readonly FileRequirementSettings _fileRequirementSettings;
        public FileRequirement(
            IOptions<FileRequirementSettings> fileRequirementSettings
            )
        {
            _fileRequirementSettings = fileRequirementSettings.Value;
        }

        public int GetMaxHeight()
        {
            return _fileRequirementSettings.MaxHeight;
        }

        public int GetMaxWidth()
        {
            return _fileRequirementSettings.MaxWidth;
        }

        public long GetMaxLength()
        {
            return _fileRequirementSettings.MaxLength;
        }

        public string GetImageFilter()
        {
            return _fileRequirementSettings.ImageFilter;
        }

        public int GetLogoMaxHeight()
        {
            return _fileRequirementSettings.LogoMaxHeight;
        }

        public int GetLogoMaxWidth()
        {
            return _fileRequirementSettings.LogoMaxWidth;
        }

        public long GetLogoMaxLength()
        {
            return _fileRequirementSettings.LogoMaxLength;
        }

        public bool CheckImage(Bitmap bm)
        {
            if (bm.Height > GetMaxHeight())
            {
                if (bm.Width > GetMaxWidth())
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckLogo(Bitmap bm)
        {
            if (bm.Height > GetLogoMaxHeight())
            {
                if (bm.Width > GetLogoMaxWidth())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
