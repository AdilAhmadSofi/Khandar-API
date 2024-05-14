﻿// <auto-generated />
using System;
using Khandar.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Khandar.Persistence.Migrations
{
    [DbContext(typeof(KhandarDbContext))]
    [Migration("20231130073156_initialmig")]
    partial class initialmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Khandar.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNative")
                        .HasColumnType("bit");

                    b.Property<string>("Landmark")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Module")
                        .HasColumnType("int");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.AppFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVideo")
                        .HasColumnType("bit");

                    b.Property<int>("Module")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("AppFiles");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.AppealVerification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("DonationAppealStatus")
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Remarks")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamAssignmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("TeamAssignmentId");

                    b.ToTable("AppealVerifications");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Donation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("AppealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentMode")
                        .HasColumnType("int");

                    b.Property<string>("Reciept")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.DonationAppeal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<Guid>("BeneficiaryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DonationAppealStatus")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiaryId");

                    b.ToTable("DonationAppeals");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Hobby", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<Guid>("PartnerSeekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("PartnerSeekerId");

                    b.ToTable("Hobbies");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.JobHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PartnerSeekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("PartnerSeekerId");

                    b.ToTable("JobHistories");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AadhaarNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MemberInvolvement")
                        .HasColumnType("int");

                    b.Property<string>("Parentage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.PartnerSeeker", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AadhaarNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AnnualIncome")
                        .HasColumnType("int");

                    b.Property<int>("BodyType")
                        .HasColumnType("int");

                    b.Property<int?>("Brothers")
                        .HasColumnType("int");

                    b.Property<int?>("BrothersMarried")
                        .HasColumnType("int");

                    b.Property<string>("Caste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Complexion")
                        .HasColumnType("int");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Disability")
                        .HasColumnType("int");

                    b.Property<bool?>("DoesHijab")
                        .HasColumnType("bit");

                    b.Property<int>("FamilyStatus")
                        .HasColumnType("int");

                    b.Property<int>("FatherStatus")
                        .HasColumnType("int");

                    b.Property<bool?>("HasBeard")
                        .HasColumnType("bit");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<int>("MotherStatus")
                        .HasColumnType("int");

                    b.Property<int>("NativeLanguage")
                        .HasColumnType("int");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parentage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfilePictureVisibilty")
                        .HasColumnType("int");

                    b.Property<int>("Religion")
                        .HasColumnType("int");

                    b.Property<int>("Religious")
                        .HasColumnType("int");

                    b.Property<int?>("Sisters")
                        .HasColumnType("int");

                    b.Property<int?>("SistersMarried")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("WorkingSector")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PartnerSeekers");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Proposal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AllowChat")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ProposalStatus")
                        .HasColumnType("int");

                    b.Property<Guid?>("RecieverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("VisibilityLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecieverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Qualification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PartnerSeekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QualificationType")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("YearOfPassing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerSeekerId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.SocialMedia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.Property<Guid>("PartnerSeekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartnerSeekerId");

                    b.ToTable("SocialMedia");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.TeamAssignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppealId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("TeamAssignStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("AppealId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamAssignments");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.TeamMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("MemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("MemberInvolvement")
                        .HasColumnType("int");

                    b.Property<int>("MemberType")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                            ConfirmationCode = "",
                            ContactNo = "9697956788",
                            CreatedBy = new Guid("6b5e075d-9c2e-4731-b76f-b76871b6e292"),
                            CreatedOn = new DateTimeOffset(new DateTime(2023, 11, 30, 13, 1, 56, 549, DateTimeKind.Unspecified).AddTicks(4806), new TimeSpan(0, 5, 30, 0, 0)),
                            Email = "rizwandar33@gmail.com",
                            Gender = 1,
                            IsEmailVerified = true,
                            Name = "Rizwan Ahmad",
                            Password = "$2a$11$TYYBxfFaSET3Oizd0CXEleNVtkdE7FEE.p60NpoAT13WT38X2OP5q",
                            ResetCode = "",
                            Salt = "$2a$11$TYYBxfFaSET3Oizd0CXEle",
                            UpdatedBy = new Guid("0acb7a72-a85c-4736-9fa2-d1c4754ec309"),
                            UpdatedOn = new DateTimeOffset(new DateTime(2023, 11, 30, 13, 1, 56, 549, DateTimeKind.Unspecified).AddTicks(4818), new TimeSpan(0, 5, 30, 0, 0)),
                            UserRole = 1,
                            UserStatus = 1,
                            Username = "rizwan"
                        });
                });

            modelBuilder.Entity("Khandar.Domain.Entities.AppealVerification", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Khandar.Domain.Entities.TeamAssignment", "TeamAssignment")
                        .WithMany()
                        .HasForeignKey("TeamAssignmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("TeamAssignment");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.DonationAppeal", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.PartnerSeeker", "PartnerSeeker")
                        .WithMany()
                        .HasForeignKey("BeneficiaryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PartnerSeeker");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Hobby", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.PartnerSeeker", "PartnerSeeker")
                        .WithMany("Hobbies")
                        .HasForeignKey("PartnerSeekerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PartnerSeeker");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.JobHistory", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.PartnerSeeker", "PartnerSeeker")
                        .WithMany("JobHistories")
                        .HasForeignKey("PartnerSeekerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PartnerSeeker");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Member", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.User", "User")
                        .WithOne("Member")
                        .HasForeignKey("Khandar.Domain.Entities.Member", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Khandar.Domain.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.PartnerSeeker", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.User", "User")
                        .WithOne("PartnerSeeker")
                        .HasForeignKey("Khandar.Domain.Entities.PartnerSeeker", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Proposal", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.PartnerSeeker", "ProposalReciever")
                        .WithMany()
                        .HasForeignKey("RecieverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Khandar.Domain.Entities.PartnerSeeker", "ProposalSender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ProposalReciever");

                    b.Navigation("ProposalSender");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Qualification", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.PartnerSeeker", "PartnerSeeker")
                        .WithMany("Qualifications")
                        .HasForeignKey("PartnerSeekerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PartnerSeeker");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.SocialMedia", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.PartnerSeeker", "PartnerSeeker")
                        .WithMany("SocialMedias")
                        .HasForeignKey("PartnerSeekerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PartnerSeeker");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.TeamAssignment", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.DonationAppeal", "DonationAppeal")
                        .WithMany()
                        .HasForeignKey("AppealId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Khandar.Domain.Entities.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DonationAppeal");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.TeamMember", b =>
                {
                    b.HasOne("Khandar.Domain.Entities.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Khandar.Domain.Entities.Team", "Team")
                        .WithMany("TeamMembers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.PartnerSeeker", b =>
                {
                    b.Navigation("Hobbies");

                    b.Navigation("JobHistories");

                    b.Navigation("Qualifications");

                    b.Navigation("SocialMedias");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.Team", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("Khandar.Domain.Entities.User", b =>
                {
                    b.Navigation("Member")
                        .IsRequired();

                    b.Navigation("PartnerSeeker")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
