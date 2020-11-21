using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.FluentValidation
{
    public static class MinLengthValidator
    {
        public static IRuleBuilderOptions<T, string> RequireDigit<T>(this IRuleBuilder<T, string> ruleBuilder, int minLength)
        {
            return ruleBuilder.Must(p => p.Length >= minLength).WithMessage($"must be more than {minLength} character");
        }
    }
}
