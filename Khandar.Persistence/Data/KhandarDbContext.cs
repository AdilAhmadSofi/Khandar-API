using Khandar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Khandar.Persistence.Data
{
    public class KhandarDbContext : DbContext
    {
        public KhandarDbContext(DbContextOptions<KhandarDbContext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationShip in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationShip.DeleteBehavior = DeleteBehavior.Restrict;

            }
            modelBuilder.SeedData();
        }


        #region dbsets
        public DbSet<User> Users { get; set; }

        public DbSet<PartnerSeeker> PartnerSeekers { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<AppFile> AppFiles { get; set; }

        public DbSet<Donation>  Donations { get; set; }

        public DbSet<DonationAppeal> DonationAppeals{ get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<JobHistory> JobHistories { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<SocialMedia> SocialMedia { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<TeamMember> TeamMembers { get; set; }

        public DbSet<TeamAssignment> TeamAssignments { get; set; }

        public DbSet<AppealVerification> AppealVerifications { get; set; }

        public DbSet<AppOrder> AppOrders { get; set; }

        public DbSet<AppPayment> AppPayments { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        #endregion

    }

    #region seed data
    public static class ModelBuilderExtentions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.Parse("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                Username = "rizwan",
                Name = "Rizwan Ahmad",
                Password = "$2a$11$TYYBxfFaSET3Oizd0CXEleNVtkdE7FEE.p60NpoAT13WT38X2OP5q",
                Salt = "$2a$11$TYYBxfFaSET3Oizd0CXEle",
                Email = "rizwandar33@gmail.com",
                ContactNo = "9697956788",
                Gender = Domain.Enums.Gender.Male,
                UserRole = Domain.Enums.UserRole.Admin,
                UserStatus = Domain.Enums.UserStatus.Active,
                ConfirmationCode = "",
                IsEmailVerified = true,
                CreatedBy = Guid.NewGuid(),
                UpdatedBy = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            });
        }


    }

    #endregion



}
