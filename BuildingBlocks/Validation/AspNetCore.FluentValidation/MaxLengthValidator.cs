using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.FluentValidation
{
    public static class MaxLengthValidator
    {
        public static IRuleBuilderOptions<T, string> RequireDigit<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength)
        {
            return ruleBuilder.Must(p => p.Length <= maxLength).WithMessage($"must be less than {maxLength} character");
        }
    }
}
