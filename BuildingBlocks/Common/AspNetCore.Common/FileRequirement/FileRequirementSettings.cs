using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Common.FileRequirement
{
    public class FileRequirementSettings
    {
        public int MaxHeight { get; set; }
        public int MaxWidth { get; set; }
        public long MaxLength { get; set; }
        public int LogoMaxHeight { get; set; }
        public int LogoMaxWidth { get; set; }
        public long LogoMaxLength { get; set; }
        public string ImageFilter { get; set; }
    }
}
