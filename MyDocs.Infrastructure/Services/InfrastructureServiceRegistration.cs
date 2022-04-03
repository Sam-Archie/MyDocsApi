using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDocs.Application.Contracts.Infrastructure;
using MyDocs.Application.Models.Mail;
using MyDocs.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDocs.Infrastructure.Services
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
