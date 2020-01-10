using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message,string userFirstName,string userLastName);
        Task Execute(string apiKey, string subject, string message, string email, string userFirstName,string userLastName);
    }
}
