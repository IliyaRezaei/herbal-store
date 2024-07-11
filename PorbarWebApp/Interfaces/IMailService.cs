using PorbarWebApp.Models;
using PorbarWebApp.Models.ServiceModels;

namespace PorbarWebApp.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendEmail(MailData mailData);
        void SendEmailConfirmation(User user, string scheme, string host, string action);
    }
}
