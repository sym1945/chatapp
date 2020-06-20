﻿using chatapp.core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatapp.web.server
{
    /// <summary>
    /// Extension methods for any SendGrid classes
    /// </summary>
    public static class SendGridExtension
    {
        /// <summary>
        /// Injects the <see cref="SendGridEmailSender"/> into the services to handle the <see cref="IEmailSender"/> service
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            // Inject the SendGridEmailSender
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            // Return collection for chaining
            return services;
        }
    }
}
