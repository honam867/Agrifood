using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCore.FluentValidation
{
    public static class RequirePunctuationValidator
    {
        public static IRuleBuilderOptions<T, string> RequirePunctuation<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must(p => p.Any(c => char.IsPunctuation(c))).WithMessage("require special character");
        }
    }
}
