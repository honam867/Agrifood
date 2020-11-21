using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Identity.Models.Users
{
    public class TLTQuotationRq
    {
        public string CompanyName { get; set; }
        public string ContactorCus { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
    }
    public class TLTQuotationRqValidator : AbstractValidator<TLTQuotationRq>
    {
        public TLTQuotationRqValidator()
        {
        }
    }
}
