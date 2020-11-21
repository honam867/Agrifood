
using ApplicationDomain.Core.Entities;
using ApplicationDomain.Core.IRepositories;
using ApplicationDomain.Core.IServices;
using ApplicationDomain.Core.Models;
using ApplicationDomain.Helper;
using ApplicationDomain.Helper.EmailTemplate;
using AspNetCore.Common.Identity;
using AspNetCore.DataBinding.AutoMapper;
using AspNetCore.EmailSender;
using AspNetCore.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDomain.Core.Services
{
    public class EmailService : ServiceBase, IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IEmailSender _emailSender;

        public EmailService(
          
            IMapper mapper,
            IUnitOfWork uow,
            IEmailRepository emailRepository,
            IEmailSender emailSender) : base(mapper, uow)
        {
            
            _emailRepository = emailRepository;
            _emailSender = emailSender;
        
        }

        public IEnumerable<EmailTemplateCreateModel> GetEmailTemplate()
        {
            return _emailRepository.GetEmailTemplate().MapQueryTo<EmailTemplateCreateModel>(_mapper);
        }

        public int CreateEmailTemplate(EmailTemplateCreateModel model, UserIdentity<int> issuer = null)
        {
            var emailTemplate = _mapper.Map<EmailTemplate>(model);
            if (issuer != null)
                emailTemplate.CreateBy(issuer).UpdateBy(issuer);
            _emailRepository.Create(emailTemplate);
            _uow.SaveChanges();
            return emailTemplate.Id;
        }

        public async Task SendEmailChangePasswordAsync(string email, string username)
        {
            EmailTemplate emailTemplate = await _emailRepository.GetEmailTemplateByNameAsync("ChangeUserPasswordEmail");
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#email", email);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#username", username);
            await _emailSender.SendEmailAsync(email, emailTemplate.EmailSubject, emailTemplate.EmailContent, true);
        }

       


       

       
 
        public async Task SendEmailResetPasswordMobile(string email,  string code)
        {
           
            EmailTemplate emailTemplate = await _emailRepository.GetEmailTemplateByNameAsync(EMAILTEMPLATE_CONSTANT.RESET_PASSWORD_MOBILE);
            EmailTemplate template = new EmailTemplate(emailTemplate);
            template.EmailContent = template.EmailContent.Replace("#email", email);
            template.EmailContent = template.EmailContent.Replace("#codereset", code);
            await _emailSender.SendEmailAsync(email, template.EmailSubject, template.EmailContent, true);
    
        }

     

        public async Task SendEmailForgotPasswordAsync(string email, string userName, string code)
        {
            string urlCode = HttpUtility.UrlEncode(code);
            string urlResetPassword = $"<a href='{AppSetting.GetValue("EmailURL:ForgotPassword")}?email={email}&code={urlCode}'>" +
                $"Nhấn vào đây để thay đổi.</a>";
            EmailTemplate emailTemplate = await _emailRepository.GetEmailTemplateByNameAsync("ResetUserPasswordEmail");
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#email", email);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#username", userName);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#password", urlResetPassword);
            await _emailSender.SendEmailAsync(email, emailTemplate.EmailSubject, emailTemplate.EmailContent, true);
        }

        public async Task SendEmailResetPasswordAsync(string email, string userName)
        {
            EmailTemplate emailTemplate = await _emailRepository.GetEmailTemplateByNameAsync("ChangeUserPasswordEmail");
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#email", email);
            emailTemplate.EmailContent = emailTemplate.EmailContent.Replace("#username", userName);
            await _emailSender.SendEmailAsync(email, emailTemplate.EmailSubject, emailTemplate.EmailContent, true);
        }

        public async Task<bool> CreateDefaultEmailTemplate ()
        {
            try
            {
                EmailTemplate et = new EmailTemplate()
                {
                    Name = "NewUserEmail",
                    EmailContent = "<span>" +
                "Xin chào #email<br /><br />" +
                "Dưới đây là thông tin đăng nhập của bạn vào hệ thống của chúng tôi:< br />" +
                "Tên đăng nhập: < b >#username</b><br />" +
                "Mật khẩu: < b >#password</b><br />" +
                "Để an toàn cho việc đăng nhập vào hệ thống, bạn vui lòng đăng nhập vào hệ thống và sử dụng chức năng đổi mật khẩu.< br />< br />" +
                "Xin cảm ơn,< br />" +
                "TLT support" +
                "</ span > ",
                    EmailSubject = "Thông tin đăng nhập hệ thống [TLTtech.vn]"
                };
                EmailTemplate cm = new EmailTemplate()
                {
                    Name = "ChangeUserPasswordEmail",
                    EmailContent = "<span>" +
                "Xin chào < b >#email</b>,<br /><br />" +
                "Mật khẩu cho tài khoản < b >#username</b> của bạn đã thay đổi.<br /><br />" +
                "Xin cảm ơn,< br />" +
                "TLT support" +
                "</ span > ",
                    EmailSubject = "Thay đổi mật khẩu đăng nhập hệ thống [TLTtech.vn]"
                };
                EmailTemplate vm = new EmailTemplate()
                {
                    Name = "ResetUserPasswordEmail",
                    EmailContent = "<span>" +
                "Xin chào < b >#email</b>,<br /><br />" +
                "Mật khẩu cho tài khoản < b >#username</b> của bạn đã thay đổi:<br />" +
                "Mật khẩu mới: < b >#password</b><br />" +
                "Để an toàn cho việc đăng nhập vào hệ thống," +
                "bạn vui lòng đăng nhập vào hệ thống và sử dụng chức năng đổi mật khẩu.< br />< br />" +
                "Xin cảm ơn,< br />" +
                "TLT support" +
                "</ span > ",
                    EmailSubject = "Khôi phục mật khẩu đăng nhập hệ thống [TLTtech.vn]"
                };
                EmailTemplate qa = new EmailTemplate()
                {
                    Name = "TLTQuotation",
                    EmailContent = "<span>" +
                "Kính gửi <b>#contactorCus</b>,<br /><br />" +
                "Đầu thư <b>#companyName</b> xin gửi đến quý khách hàng lời chào trân trọng.<br /><br />" +
                "<b>#companyName</b> gửi đến quý khách hàng báo giá chi tiết như sau.<br /><br />" +
                "Vui lòng truy cập <b>#url</b> để xem chi tiết báo giá.<br /><br />" +
                "Trân trọng,<br /><br />" +
                "TLT support <br /><br />" +
                "</ span > ",
                    EmailSubject = "Báo giá tới quý khách hàng [TLTtech.vn]"
                };
                EmailTemplate se = new EmailTemplate()
                {
                    Name = "Send",
                    EmailContent = "<span>" +
               "Kính gửi <b>#managerName</b>,<br /><br />" +
               "Báo giá <b>#quotationCode</b> được gửi đến <b>#managerName</b> .<br /><br />" +
               "<b>#managerName</b> Vui lòng kiểm tra báo giá để xem chi tiết.<br /><br />" +
               "Trân trọng,<br /><br />" +
               "TLT support <br /><br />" +
               "</ span > ",
                    EmailSubject = "Báo giá được gửi [TLTtech.vn]"
                };
                EmailTemplate csn = new EmailTemplate()
                {
                    Name = "ContractSubmitedNotificationMail",
                    EmailContent = "<span>" +
               "Kính gửi <b>#receiverName</b>,<br /><br />" +
               "Hợp đồng <b>#contractCode</b> được gửi đến <b>#receiverName</b> đang chờ duyệt.<br /><br />" +
               "Được gửi bởi nhân viên <b>#senderName<b>.<br /><br />" +
               "<b>Vui lòng kiểm tra hợp đồng để xem chi tiết.</b><br /><br />" +
               "Trân trọng,<br /><br />" +
               "TLT support <br /><br />" +
               "</ span > ",
                    EmailSubject = "Hợp đồng được trình duyệt [TLTtech.vn]"
                };
                EmailTemplate crn = new EmailTemplate()
                {
                    Name = "ContractRecalledNotificationMail",
                    EmailContent = "<span>" +
               "Kính gửi <b>#receiverName</b>,<br /><br />" +
               "Hợp đồng <b>#contractCode</b> đã được thu hồi bởi <b>#senderName<b>.<br /><br />" +
               "<b>Vui lòng liên hệ <b>#senderName</b> để biết thêm chi tiết.</b><br /><br />" +
               "Trân trọng,<br /><br />" +
               "TLT support <br /><br />" +
               "</ span > ",
                    EmailSubject = "Hợp đồng được thu hồi [TLTtech.vn]"
                };
                EmailTemplate can = new EmailTemplate()
                {
                    Name = "ContractApprovedNotificationMail",
                    EmailContent = "<span>" +
               "Kính gửi <b>#receiverName</b>,<br /><br />" +
               "Hợp đồng <b>#contractCode</b> mà bạn đã trình duyệt đã được phê duyệt bởi <b>#senderName<b>.<br /><br />" +
               "<b>Vui lòng kiểm tra hợp đồng để xem chi tiết.</b><br /><br />" +
               "Trân trọng,<br /><br />" +
               "TLT support <br /><br />" +
               "</ span > ",
                    EmailSubject = "Hợp đồng được phê duyệt [TLTtech.vn]"
                };
                EmailTemplate crjn = new EmailTemplate()
                {
                    Name = "ContractRejectedNotificationMail",
                    EmailContent = "<span>" +
               "Kính gửi <b>#receiverName</b>,<br /><br />" +
               "Hợp đồng <b>#contractCode</b> mà bạn đã trình duyệt đã bị từ chối bởi <b>#senderName<b>.<br /><br />" +
               "<b>Vui lòng kiểm tra lại hợp đồng và liên hệ <b>#senderName</b> để biết thêm chi tiết.</b><br /><br />" +
               "Trân trọng,<br /><br />" +
               "TLT support <br /><br />" +
               "</ span > ",
                    EmailSubject = "Hợp đồng bị từ chối [TLTtech.vn]"
                };
                EmailTemplate ccn = new EmailTemplate()
                {
                    Name = "ContractCanceledNotificationMail",
                    EmailContent = "<span>" +
               "Kính gửi <b>#receiverName</b>,<br /><br />" +
               "Hợp đồng <b>#contractCode</b> bạn đã duyệt đã bị hủy bởi nhân viên <b>#senderName<b>.<br /><br />" +
               "<b>Vui lòng liên hệ <b>#senderName</b> để biết thêm chi tiết.</b><br /><br />" +
               "Trân trọng,<br /><br />" +
               "TLT support <br /><br />" +
               "</ span > ",
                    EmailSubject = "Hợp đồng bị hủy [TLTtech.vn]"
                };
                if (!await _emailRepository.CheckNameExistsAsync("NewUserEmail"))
                    _emailRepository.Create(et);
                if (!await _emailRepository.CheckNameExistsAsync("ChangeUserPasswordEmail"))
                    _emailRepository.Create(cm);
                if (!await _emailRepository.CheckNameExistsAsync("ResetUserPasswordEmail"))
                    _emailRepository.Create(vm);
                if (!await _emailRepository.CheckNameExistsAsync("TLTQuotation"))
                    _emailRepository.Create(qa);
                if (!await _emailRepository.CheckNameExistsAsync("Send"))
                    _emailRepository.Create(se);
                if (!await _emailRepository.CheckNameExistsAsync("ContractSubmitedNotificationMail"))
                    _emailRepository.Create(csn);
                if (!await _emailRepository.CheckNameExistsAsync("ContractRecalledNotificationMail"))
                    _emailRepository.Create(crn);
                if (!await _emailRepository.CheckNameExistsAsync("ContractApprovedNotificationMail"))
                    _emailRepository.Create(can);
                if (!await _emailRepository.CheckNameExistsAsync("ContractRejectedNotificationMail"))
                    _emailRepository.Create(crjn);
                if (!await _emailRepository.CheckNameExistsAsync("ContractCanceledNotificationMail"))
                    _emailRepository.Create(ccn);
                if (await _uow.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
