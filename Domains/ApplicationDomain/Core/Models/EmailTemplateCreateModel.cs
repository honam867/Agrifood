using ApplicationDomain.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Core.Models
{
    public class EmailTemplateCreateModel
    {
        public string Name { get; set; }
        public string EmailContent { get; set; }
        public string EmailSubject { get; set; }
    }

    public class EmailTemplateCreateModelMapper : Profile
    {
        public EmailTemplateCreateModelMapper()
        {
            CreateMap<EmailTemplateCreateModel, EmailTemplate>();
            CreateMap<EmailTemplate, EmailTemplateCreateModel>();
        }
    }
}
