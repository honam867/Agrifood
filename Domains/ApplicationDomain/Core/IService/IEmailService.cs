
using ApplicationDomain.Core.Models;
using AspNetCore.Common.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDomain.Core.IServices
{
    public interface IEmailService
    {
        IEnumerable<EmailTemplateCreateModel> GetEmailTemplate();
        int CreateEmailTemplate(EmailTemplateCreateModel model, UserIdentity<int> issuer = null);
        Task SendEmailChangePasswordAsync(string email, string username);
     Task SendEmailResetPasswordAsync(string email, string userName);
        Task SendEmailForgotPasswordAsync(string email, string userName, string code);


    }
}
