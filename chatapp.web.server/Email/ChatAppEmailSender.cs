using chatapp.core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatapp.web.server
{
    /// <summary>
    /// Handles sending emails specific to the chat app server
    /// </summary>
    public class ChatAppEmailSender
    {
        private readonly IEmailTemplateSender mEmailTemplateSender;
        private readonly IConfiguration mConfiguration;

        public ChatAppEmailSender(IEmailTemplateSender emailTemplateSender, IConfiguration configuration)
        {
            mEmailTemplateSender = emailTemplateSender;
            mConfiguration = configuration;
        }


        /// <summary>
        /// Sends a verification email to the specified user
        /// </summary>
        /// <param name="displayName">The users display name (typically first name)</param>
        /// <param name="email">The users email to be verified</param>
        /// <param name="verificationUrl">The URL the user needs to click to verify their email</param>
        /// <returns></returns>
        public async Task<SendEmailResponse> SendUserVerificationEmailAsync(string displayName, string email, string verificationUrl)
        {
            return await mEmailTemplateSender.SendGeneralEmailAsync(new SendEmailDetails
            {
                IsHTML = true,
                FromEmail = mConfiguration["ChatAppSettings:SendEmailFromEmail"],
                FromName = mConfiguration["ChatAppSettings:SendEmailFromName"],
                ToEmail = email,
                ToName = displayName,
                Subject = "Verify Your Email - Chat App"
            },
            "Verify Email",
            $"Hi {displayName ?? "stranger"},",
            "Thanks for creating an account with us.<br/>To continue please verify your email with us.",
            "Verify Email",
            verificationUrl
            );
        }
    }



    /// <summary>
    /// Extension methods for any ChatAppEmailSender classes
    /// </summary>
    public static class ChatAppEmailSenderExtensions
    {
        /// <summary>
        /// Injects the <see cref="ChatAppEmailSender"/> into the services to handle the 
        /// <see cref="ChatAppEmailSender"/> service
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddChatAppEmailSender(this IServiceCollection services)
        {
            // Inject the EmailTemplateSender
            services.AddSingleton<ChatAppEmailSender>();

            // Return collection for chaining
            return services;
        }
    }
}
