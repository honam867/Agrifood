using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCore.FluentValidation
{
    public static class RequireUppercaseValidator
    {
        public static IRuleBuilderOptions<T, string> RequireUppercase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(p => p.Any(c => char.IsUpper(c))).WithMessage("require uppercase character");
        }
    }
}
