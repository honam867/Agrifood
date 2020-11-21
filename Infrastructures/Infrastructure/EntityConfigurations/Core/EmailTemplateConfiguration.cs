using ApplicationDomain.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.EntityConfigurations.Core
{
    public class EmailTemplateConfiguration : EntityConfigurationBase<EmailTemplate, int>
    {
        public override void OnConfigure(EntityTypeBuilder<EmailTemplate> builder)
        {
        }
    }
}
