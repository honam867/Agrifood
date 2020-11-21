using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCore.FluentValidation
{
    public static class RequireLowercaseValidator
    {
        public static IRuleBuilderOptions<T, string> RequireUppercase<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(p => p.Any(c => char.IsLower(c))).WithMessage("require lowercase character");
        }
    }
}
