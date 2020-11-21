using ApplicationDomain.Core.Models;
using AspNetCore.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.Core.Entities
{
    public class EmailTemplate: EntityBase<int>
    {
        public string Name { set; get; }
        public string EmailContent { set; get; }
        public string EmailSubject { set; get; }

        public EmailTemplate()
        {
            var now = DateTimeOffset.UtcNow;
            CreatedDate = now;
            UpdatedDate = now;
            CreatedByUserName = "";
            UpdatedByUserName = "";
        }

        public EmailTemplate(EmailTemplate emailTemplate)
        {
            var now = DateTimeOffset.UtcNow;
            CreatedDate = now;
            UpdatedDate = now;
            CreatedByUserName = "";
            UpdatedByUserName = "";
            this.Name = emailTemplate.Name;
            this.EmailSubject = emailTemplate.EmailSubject;
            this.EmailContent = emailTemplate.EmailContent;
        }
    }

    public class EmailTemplateMapper : Profile
    {
        public EmailTemplateMapper()
        {
            CreateMap<EmailTemplateCreateModel, EmailTemplate>();
        }
    }
}
