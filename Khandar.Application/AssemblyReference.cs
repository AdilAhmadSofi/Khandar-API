using KashmirServices.Application.Abstractions.IServices;
using KashmirServices.Application.Services;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.IServices;
using Khandar.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Khandar.Application
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, string webrootPath)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IPartnerSeekerService, PartnerSeekerService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<IFileService>(new FileService(webrootPath));
            // services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IHobbyService, HobbyService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<IQualificationService, QualificationService>();
            services.AddScoped<IProposalService, ProposalService>();
            services.AddScoped<IDonationService, DonationService>();
            services.AddScoped<IDonationAppealService, DonationAppealService>();
            services.AddScoped<IJobHistoryService, JobHistoryService>();
            services.AddScoped<ITeamAssignmentService, TeamAssignmentService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamMemberService, TeamMemberService>();
            services.AddScoped<IAppealVerificationService, AppealVerificationService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ITestimonialService, TestimonialService>();

            return services;
        }
    }
}
