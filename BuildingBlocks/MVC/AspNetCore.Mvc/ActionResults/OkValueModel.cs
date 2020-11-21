using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Mvc.ActionResults
{
    public class OkValueModel
    {
        public object Value { set; get; }
        public OkValueModel(object value)
        {
            this.Value = value;
        }
    }
}
