using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PorbarWebApp.Interfaces;
using System.Net.Mail;
using System.Net;
using System.Text;
using PorbarWebApp.Models;
using PorbarWebApp.Models.ServiceModels;

namespace PorbarWebApp.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly UserManager<User> _userManager;
        public MailService(IOptions<MailSettings> mailSettingsOptions, UserManager<User> userManager)
        {
            _mailSettings = mailSettingsOptions.Value;
            _userManager = userManager;
        }

        public async Task<bool> SendEmail(MailData mailData)
        {
            try
            {
                SmtpClient client = new SmtpClient(_mailSettings.Server, _mailSettings.Port)
                {
                    Credentials = new NetworkCredential(_mailSettings.UserName, _mailSettings.Password),
                    EnableSsl = true
                };
                MailMessage message = new MailMessage(
                    _mailSettings.SenderEmail,
                    mailData.EmailToEmail,
                    mailData.EmailSubject,
                    mailData.EmailBody)
                {
                    Body = mailData.EmailBody,
                    BodyEncoding = Encoding.UTF8,
                    Subject = mailData.EmailSubject,
                    SubjectEncoding = Encoding.UTF8,
                    IsBodyHtml = true
                };
                await client.SendMailAsync(message);
                message.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async void SendEmailConfirmation(User user, string scheme, string host, string action)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            var emailBody = $"please confirm your email address <a href='#URL'>Click Here</a>";

            var callbackUrl = scheme + "://" + host + action;

            var body = emailBody.Replace("#URL", callbackUrl);

            MailData mailData = new MailData
            {
                EmailToEmail = user.Email,
                EmailSubject = "Confirm Your Email",
                EmailBody = body
            };
            var bol = await SendEmail(mailData);
        }
    }
}
