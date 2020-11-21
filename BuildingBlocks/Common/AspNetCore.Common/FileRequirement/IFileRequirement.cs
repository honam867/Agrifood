using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AspNetCore.Common.FileRequirement
{
    public interface IFileRequirement
    {
        int GetMaxHeight();
        int GetLogoMaxHeight();
        int GetMaxWidth();
        int GetLogoMaxWidth();
        long GetMaxLength();
        long GetLogoMaxLength();
        string GetImageFilter();
        bool CheckImage(Bitmap bm);
        bool CheckLogo(Bitmap bm);
    }
}
