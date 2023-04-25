using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Email.Customs.Interface
{
    public interface ICustomEmailSender
    {

        Task SendCustomEmailAsync(string email, string subject, string htmlMessage);
        Task SendBannedNotification(string email);
        Task SendMuteNotification(string email);
        Task SendConfirmationEmailAsync(string email, string callback);
        Task SendForgotPasswordEmail(string email, string callback);
    }
}
