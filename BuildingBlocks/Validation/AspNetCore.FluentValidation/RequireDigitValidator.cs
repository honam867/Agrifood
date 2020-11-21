using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCore.FluentValidation
{
    public static class RequireDigitValidator
    {
        public static IRuleBuilderOptions<T, string> RequireDigit<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(p => p.Any(c => char.IsNumber(c))).WithMessage("require digit character");
        }
    }
}
