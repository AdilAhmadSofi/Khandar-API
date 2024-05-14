using KashmirServices.Persistence.Repositories;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.Abstractions.IRepository;
using Khandar.Persistence.Data;
using Khandar.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Khandar.Persistence
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<KhandarDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(KhandarDbContext))));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAppFileRepository,AppFileRepository>();
            services.AddScoped<IPartnerSeekerRepository, PartnerSeekerRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IHobbyRepository,HobbyRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IQualificationRepository,QualificationRepository>();
            services.AddScoped<IDonationRepository,DonationRepository>();
            services.AddScoped<IDonationAppealRepository,DonationAppealRepository>();
            services.AddScoped<IJobHistoryRepository,JobHistoryRepository>();
            services.AddScoped<ITeamAssignmentRepository,TeamAssignmentRepository>();
            services.AddScoped<ITeamRepository,TeamRepository>();
            services.AddScoped<ITeamMemberRepository,TeamMemberRepository>();
            services.AddScoped<IAppealVerificationRepostory,AppealVerificationRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
           
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();

            return services;
        }
    }
}
