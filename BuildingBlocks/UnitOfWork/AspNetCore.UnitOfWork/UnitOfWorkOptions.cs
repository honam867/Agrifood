using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.UnitOfWork
{
    public class UnitOfWorkOptions
    {
        public TimeSpan? Timeout { set; get; }
    }
}
