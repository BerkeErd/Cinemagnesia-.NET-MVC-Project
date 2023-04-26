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
        Task SendBannedNotificationEmailAsync(string email, int? days);
        Task SendMutedNotificationEmailAsync(string email, int? days);
        Task SendConfirmationEmailAsync(string email, string callback);
        Task SendForgotPasswordEmailAsync(string email, string callback);
        Task SendProductorRequestCreatedEmailAsync(string email);
        Task SendProductorRequestApprovedEmailAsync(string email);
        Task SendProductorRequestRejectedEmailAsync(string email);
    }
}
