using chatapp.core;
using Microsoft.Extensions.DependencyInjection;

namespace chatapp.web.server
{
    /// <summary>
    /// Extension methods for any EmailTemplateSender classes
    /// </summary>
    public static class EmailTemplateSenderExtensions
    {
        /// <summary>
        /// Injects the <see cref="EmailTemplateSender"/> into the services to handle the 
        /// <see cref="IEmailTemplateSender"/> service
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddEmailTemplateSender(this IServiceCollection services)
        {
            // Inject the EmailTemplateSender
            services.AddTransient<IEmailTemplateSender, EmailTemplateSender>();

            // Return collection for chaining
            return services;
        }
    }
}
