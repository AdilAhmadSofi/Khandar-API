using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.ExceptionNotifier;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IEmailService;
using Khandar.Application.Abstractions.IPaymentGatewayService;
using Khandar.Application.Abstractions.JWT;
using Khandar.Application.Abstractions.TemplateRenderer;
using Khandar.Application.Services;
using Khandar.Infrastructure.EmailService.MailJetServices;
using Khandar.Infrastructure.ExceptionNotifier;
using Khandar.Infrastructure.Identity;
using Khandar.Infrastructure.JWT;
using Khandar.Infrastructure.RazorPayServices;
using Khandar.Infrastructure.TemplateRenderer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Khandar.Infrastructure
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailJetOptions>(configuration.GetSection("MailJetOptionSection"));
            services.AddScoped<IEmailTemplateRenderer, EmailTemplateRenderer>();
            services.AddSingleton<IContextService, ContextService>();
            services.AddTransient<IEmailService, MailJetEmailService>();
            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddTransient<IExceptionNotifier, EmailExceptionLogger>();
            services.Configure<PaymentOptions>(configuration.GetSection("RazorPaySection"));
            services.AddScoped<IPaymentGatewayService, RazorPayService>();


            return services;
        }
    }
}
