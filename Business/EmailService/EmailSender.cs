using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Business.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;

        }
        public AuthMessageSenderOptions Options { get; }

        public Task SendEmailAsync(string email, string subject, string message,string userFirstName,string userLastName)
        {
            return Execute(Options.SendGridKey, subject, message, email,userFirstName,userLastName);
        }

        public async Task Execute(string apiKey, string subject, string message, string email, string userFirstName, string userLastName)
        {
            var apiKeyGeneration = String.IsNullOrEmpty(apiKey) ? "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" : apiKey;
            var client = new SendGridClient(apiKeyGeneration);

            // Send a Single Email using the Mail Helper, entirely with convenience methods
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("fantastikrehber@gmail.com", "Fantastik Rehber"));
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Text, message);
            msg.AddContent(MimeType.Html, message);
            msg.AddTo(new EmailAddress(email, $"{userFirstName} {userLastName}"));

            var response = await client.SendEmailAsync(msg);
        }
    }
}
