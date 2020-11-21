using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.EntityFramework
{
    public interface IEntityConfiguration
    {
        void Configure(ModelBuilder builder);
    }
}
