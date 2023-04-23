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
        Task SendConfirmationEmailAsync(string email, string callback);
    }
}
