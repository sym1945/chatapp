using chatapp.core;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace chatapp.web.server
{
    /// <summary>
    /// Sends emails using the SendGrid service
    /// </summary>
    public class SendGridEmailSender : IEmailSender
    {
        public IConfiguration Configuration { get; }

        public SendGridEmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details)
        {
            // Get the SendGrid key
            var apiKey = Configuration["SendGridKey"];

            // Create a new SendGrid client
            var client = new SendGridClient(apiKey);

            // From
            var from = new EmailAddress(details.FromEmail, details.FromName);

            // To
            var to = new EmailAddress(details.ToEmail, details.ToName);

            // Subject
            var subject = details.Subject;
            
            // Create Email class ready to send
            var msg = MailHelper.CreateSingleEmail(
                from, 
                to, 
                subject, 
                // Plain content
                details.IsHTML ? null : details.Content, 
                // HTML content
                details.IsHTML ? details.Content : null);

            // Finally, send the email...
            var response = await client.SendEmailAsync(msg);

            // Return result based on response
            return new SendEmailResponse();
        }
    }
}