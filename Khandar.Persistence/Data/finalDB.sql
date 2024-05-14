USE [KhandarDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [uniqueidentifier] NOT NULL,
	[State] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[AddressLine] [nvarchar](max) NOT NULL,
	[Landmark] [nvarchar](max) NOT NULL,
	[PinCode] [nvarchar](max) NOT NULL,
	[IsNative] [bit] NOT NULL,
	[EntityId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Module] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppealVerifications]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppealVerifications](
	[Id] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
	[TeamAssignmentId] [uniqueidentifier] NOT NULL,
	[Feedback] [nvarchar](max) NULL,
	[Remarks] [int] NULL,
	[DonationAppealStatus] [int] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_AppealVerifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppFiles]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppFiles](
	[Id] [uniqueidentifier] NOT NULL,
	[Module] [int] NOT NULL,
	[FilePath] [nvarchar](max) NOT NULL,
	[IsVideo] [bit] NOT NULL,
	[EntityId] [uniqueidentifier] NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_AppFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonationAppeals]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonationAppeals](
	[Id] [uniqueidentifier] NOT NULL,
	[BeneficiaryId] [uniqueidentifier] NOT NULL,
	[Amount] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DonationAppealStatus] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_DonationAppeals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donations]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donations](
	[Id] [uniqueidentifier] NOT NULL,
	[AppealId] [uniqueidentifier] NOT NULL,
	[EntityId] [uniqueidentifier] NULL,
	[Name] [nvarchar](max) NULL,
	[PaymentMode] [int] NOT NULL,
	[Bank] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[TransactionId] [nvarchar](max) NULL,
	[Reciept] [nvarchar](max) NOT NULL,
	[OrderId] [nvarchar](max) NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Donations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hobbies]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hobbies](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [int] NOT NULL,
	[PartnerSeekerId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Hobbies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobHistories]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobHistories](
	[Id] [uniqueidentifier] NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[Company] [nvarchar](max) NOT NULL,
	[From] [datetime2](7) NOT NULL,
	[To] [datetime2](7) NOT NULL,
	[PartnerSeekerId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_JobHistories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[Id] [uniqueidentifier] NOT NULL,
	[Parentage] [nvarchar](max) NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[AadhaarNo] [nvarchar](max) NOT NULL,
	[MemberInvolvement] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[TeamId] [uniqueidentifier] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PartnerSeekers]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartnerSeekers](
	[Id] [uniqueidentifier] NOT NULL,
	[Parentage] [nvarchar](max) NOT NULL,
	[AadhaarNo] [nvarchar](max) NOT NULL,
	[Caste] [nvarchar](max) NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Religion] [int] NOT NULL,
	[Religious] [int] NOT NULL,
	[HasBeard] [bit] NULL,
	[DoesHijab] [bit] NULL,
	[NativeLanguage] [int] NOT NULL,
	[MaritalStatus] [int] NOT NULL,
	[Occupation] [nvarchar](max) NOT NULL,
	[WorkingSector] [int] NOT NULL,
	[AnnualIncome] [int] NOT NULL,
	[Disability] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[BodyType] [int] NOT NULL,
	[Complexion] [int] NOT NULL,
	[FamilyStatus] [int] NOT NULL,
	[FatherStatus] [int] NOT NULL,
	[MotherStatus] [int] NOT NULL,
	[Brothers] [int] NULL,
	[BrothersMarried] [int] NULL,
	[Sisters] [int] NULL,
	[SistersMarried] [int] NULL,
	[ProfilePictureVisibilty] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_PartnerSeekers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proposals]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proposals](
	[Id] [uniqueidentifier] NOT NULL,
	[SenderId] [uniqueidentifier] NULL,
	[RecieverId] [uniqueidentifier] NULL,
	[ProposalStatus] [int] NOT NULL,
	[VisibilityLevel] [int] NOT NULL,
	[AllowChat] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Proposals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Qualifications]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Qualifications](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[QualificationType] [int] NOT NULL,
	[Institution] [nvarchar](max) NOT NULL,
	[YearOfPassing] [nvarchar](max) NOT NULL,
	[PartnerSeekerId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Qualifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SocialMedia]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SocialMedia](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [int] NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[PartnerSeekerId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_SocialMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamAssignments]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamAssignments](
	[Id] [uniqueidentifier] NOT NULL,
	[AppealId] [uniqueidentifier] NOT NULL,
	[TeamId] [uniqueidentifier] NOT NULL,
	[TeamAssignStatus] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TeamAssignments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamMembers]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamMembers](
	[Id] [uniqueidentifier] NOT NULL,
	[MemberId] [uniqueidentifier] NOT NULL,
	[MemberType] [int] NOT NULL,
	[MemberInvolvement] [int] NOT NULL,
	[TeamId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_TeamMembers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03-12-2023 03:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Gender] [int] NOT NULL,
	[Username] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[ContactNo] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Salt] [nvarchar](max) NOT NULL,
	[ResetCode] [nvarchar](max) NOT NULL,
	[ConfirmationCode] [nvarchar](max) NOT NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[UserRole] [int] NOT NULL,
	[UserStatus] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231130073156_initialmig', N'7.0.10')
GO
INSERT [dbo].[Addresses] ([Id], [State], [City], [AddressLine], [Landmark], [PinCode], [IsNative], [EntityId], [IsDeleted], [Module], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'2affcbe2-dbac-4622-b76a-779e090857b8', N'Dadar and Nagar Haveli', N'Bandipora', N'Baghat', N'1kdjalkj', N'190005', 1, N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', 0, 0, N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', NULL, CAST(N'2023-12-02T23:52:47.7813179+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Addresses] ([Id], [State], [City], [AddressLine], [Landmark], [PinCode], [IsNative], [EntityId], [IsDeleted], [Module], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e422df96-99bc-4e98-80c0-df4badcc58c6', N'Jammu and Kashmir', N'Srinagar', N'barzulla srinagar', N'EIGDKJAL', N'190005', 1, N'b862986f-234e-4716-916b-805f7e390d2a', 0, 0, N'b862986f-234e-4716-916b-805f7e390d2a', NULL, CAST(N'2023-12-02T23:17:49.1366946+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'38bca19d-eaf3-4d7e-ad21-5f64fbc5173c', N'0601cd4f-15bd-443b-a1f3-2a6996949994', N'a4ce661d-c2bf-457f-8de5-d240fb6deddc', N'hey', 1, NULL, NULL, NULL, CAST(N'2023-12-03T02:25:15.0524859+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'a9b3a4a4-b31e-4a2c-8fa4-9b1857eaea18', N'0601cd4f-15bd-443b-a1f3-2a6996949994', N'18761441-1ae2-402d-9f81-f399933d3301', N'hey', 1, NULL, NULL, NULL, CAST(N'2023-12-03T02:01:23.6758088+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'cc179a2f-e902-4c1e-be18-0edaf1eb7d3e', 2, N'Files\Images\aeb2a428-c72a-4f30-8ad9-1713ed9ae5baProfile.jpg', 0, N'b862986f-234e-4716-916b-805f7e390d2a', N'b862986f-234e-4716-916b-805f7e390d2a', NULL, CAST(N'2023-12-02T23:02:32.3220615+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'd60c5f9c-57b0-4d99-86f1-0fd98450598a', 5, N'Files\Images\0e51442a-24f5-42a9-bf89-c74f90afb9fevid.mp4', 0, N'60fa1723-a613-4a23-9a07-c832debd5d34', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', NULL, CAST(N'2023-12-01T00:38:41.4508415+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'f3b76007-0d3a-4e69-999c-105c6d9a5c5a', 5, N'Files\Images\f9c5d762-f119-4dad-b051-8b570979b198#tomandjerry #bestfriend 😭Tom And Jerry Last Episode Sad Status 🙂 Tom And Jerry 🥀 JKA CREATIVE.mp4', 0, N'44a0d59c-a97d-44d5-b10a-6b894ae31760', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', NULL, CAST(N'2023-12-01T00:25:52.0007627+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'daea20c0-4f8c-414e-80f3-25f69a23ff74', 5, N'Files\Images\5add4b14-64a6-4c2e-a31b-6f2fea885063Online Examination System Documentation.docx', 0, N'7c7e4188-0f94-4f5d-a9fc-c3817962d14b', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', NULL, CAST(N'2023-12-02T23:53:15.2169863+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'4dad8a69-8f68-4909-af7f-63daa01ac512', 5, N'Files\Images\1f851406-5e23-476f-bc09-798cde3f9767vid.mp4', 1, N'7fc58ef9-1b6c-4725-a602-b668b6f19484', N'b862986f-234e-4716-916b-805f7e390d2a', NULL, CAST(N'2023-12-02T23:18:21.0997333+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'd52f9606-54f3-4cad-bd6d-780bf7a9b47a', 5, N'Files\Images\3927ad5c-77aa-4575-aab5-0a1f0999f3eavid.mp4', 0, N'237e5d3c-f4fd-417c-8b70-a4c8078c43be', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', CAST(N'2023-12-01T00:44:19.5035086+05:30' AS DateTimeOffset), CAST(N'2023-12-01T01:17:05.3624039+05:30' AS DateTimeOffset))
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'137c4096-2b48-4636-a00d-79c089f9a7ce', 5, N'Files\Images\3a142b48-48a0-472c-86f5-5578657d16bbvid.mp4', 1, N'5d7c9db0-4c67-44fa-9d7a-00338076c7cf', N'b862986f-234e-4716-916b-805f7e390d2a', NULL, CAST(N'2023-12-02T23:46:57.2761697+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'c0af979a-6d69-4665-8995-bdb9ff4e6921', 5, N'Files\Images\505c01fe-8340-4912-92be-c8d212fc9513logo.jpeg', 0, N'27a24c60-43e2-4fb4-b7e6-55108a661ec4', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', NULL, CAST(N'2023-11-30T23:58:16.8047904+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[DonationAppeals] ([Id], [BeneficiaryId], [Amount], [Description], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'5d7c9db0-4c67-44fa-9d7a-00338076c7cf', N'b862986f-234e-4716-916b-805f7e390d2a', 100010, N'321000', 2, NULL, NULL, CAST(N'2023-12-02T23:46:57.2360321+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[DonationAppeals] ([Id], [BeneficiaryId], [Amount], [Description], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'7c7e4188-0f94-4f5d-a9fc-c3817962d14b', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', 10000, N'this is me', 2, NULL, NULL, CAST(N'2023-12-02T23:53:15.2069830+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [TeamId], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'88a20fea-e7aa-46d2-9f4e-055aa2e5f494', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', NULL, 1, N'88a20fea-e7aa-46d2-9f4e-055aa2e5f494', N'88a20fea-e7aa-46d2-9f4e-055aa2e5f494', CAST(N'2023-11-30T16:04:31.5362089+05:30' AS DateTimeOffset), CAST(N'2023-11-30T18:04:00.9928462+05:30' AS DateTimeOffset))
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [TeamId], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e0985d7f-d3a4-48b0-9bfe-26efa68e8c56', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', NULL, 0, N'e0985d7f-d3a4-48b0-9bfe-26efa68e8c56', NULL, CAST(N'2023-11-30T13:15:59.5137699+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [TeamId], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'0601cd4f-15bd-443b-a1f3-2a6996949994', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', NULL, 0, N'0601cd4f-15bd-443b-a1f3-2a6996949994', NULL, CAST(N'2023-11-30T15:45:48.1134504+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [TeamId], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'594f0759-4050-48fe-8d42-b8402ed239b0', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', NULL, 0, N'594f0759-4050-48fe-8d42-b8402ed239b0', NULL, CAST(N'2023-11-30T16:05:49.0049112+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[PartnerSeekers] ([Id], [Parentage], [AadhaarNo], [Caste], [DOB], [Religion], [Religious], [HasBeard], [DoesHijab], [NativeLanguage], [MaritalStatus], [Occupation], [WorkingSector], [AnnualIncome], [Disability], [Height], [BodyType], [Complexion], [FamilyStatus], [FatherStatus], [MotherStatus], [Brothers], [BrothersMarried], [Sisters], [SistersMarried], [ProfilePictureVisibilty], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'660914c2-b671-4d32-beb8-617682ceb2cc', N'Bashir', N'112233665544', N'Sofi', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 2, 0, 0, 0, 1, 1, N'Student', 0, 5, 1, 20, 1, 2, 1, 2, 1, 3, 2, 3, 0, 0, N'', 0, N'660914c2-b671-4d32-beb8-617682ceb2cc', N'660914c2-b671-4d32-beb8-617682ceb2cc', CAST(N'2023-11-30T17:22:12.5245108+05:30' AS DateTimeOffset), CAST(N'2023-11-30T17:25:14.1209735+05:30' AS DateTimeOffset))
INSERT [dbo].[PartnerSeekers] ([Id], [Parentage], [AadhaarNo], [Caste], [DOB], [Religion], [Religious], [HasBeard], [DoesHijab], [NativeLanguage], [MaritalStatus], [Occupation], [WorkingSector], [AnnualIncome], [Disability], [Height], [BodyType], [Complexion], [FamilyStatus], [FatherStatus], [MotherStatus], [Brothers], [BrothersMarried], [Sisters], [SistersMarried], [ProfilePictureVisibilty], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'b862986f-234e-4716-916b-805f7e390d2a', N'Bashir', N'1111222233330001', N'Dar', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 2, 1, 0, 0, 11, 1, N'Developer', 0, 6, 1, 16, 3, 4, 1, 1, 1, 2, 0, 0, 0, 0, N'', 0, N'b862986f-234e-4716-916b-805f7e390d2a', N'b862986f-234e-4716-916b-805f7e390d2a', CAST(N'2023-12-02T22:51:00.4633156+05:30' AS DateTimeOffset), CAST(N'2023-12-02T23:02:32.2724492+05:30' AS DateTimeOffset))
INSERT [dbo].[PartnerSeekers] ([Id], [Parentage], [AadhaarNo], [Caste], [DOB], [Religion], [Religious], [HasBeard], [DoesHijab], [NativeLanguage], [MaritalStatus], [Occupation], [WorkingSector], [AnnualIncome], [Disability], [Height], [BodyType], [Complexion], [FamilyStatus], [FatherStatus], [MotherStatus], [Brothers], [BrothersMarried], [Sisters], [SistersMarried], [ProfilePictureVisibilty], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', N'Rashid', N'23115643', N'Dar', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, 1, 0, 0, 2, 1, N'none', 0, 3, 1, 26, 2, 2, 1, 1, 1, 2, 2, 2, 2, 0, N'', 0, N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', CAST(N'2023-11-30T23:27:48.8967758+05:30' AS DateTimeOffset), CAST(N'2023-12-02T23:51:27.5663047+05:30' AS DateTimeOffset))
GO
INSERT [dbo].[TeamAssignments] ([Id], [AppealId], [TeamId], [TeamAssignStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'a4ce661d-c2bf-457f-8de5-d240fb6deddc', N'7c7e4188-0f94-4f5d-a9fc-c3817962d14b', N'21089e5e-6d4b-4405-96ba-156ceaceef03', 2, NULL, NULL, CAST(N'2023-12-02T23:54:05.1555210+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamAssignments] ([Id], [AppealId], [TeamId], [TeamAssignStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'18761441-1ae2-402d-9f81-f399933d3301', N'5d7c9db0-4c67-44fa-9d7a-00338076c7cf', N'21089e5e-6d4b-4405-96ba-156ceaceef03', 2, NULL, NULL, CAST(N'2023-12-02T23:54:00.4620102+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'd15a7e2f-54d9-42c5-a9a4-2d30f6011d77', N'e0985d7f-d3a4-48b0-9bfe-26efa68e8c56', 1, 1, N'21089e5e-6d4b-4405-96ba-156ceaceef03', NULL, NULL, CAST(N'2023-11-30T20:19:08.1938720+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'69413dc9-6d51-43e4-b3d1-6c1942436d05', N'0601cd4f-15bd-443b-a1f3-2a6996949994', 3, 1, N'21089e5e-6d4b-4405-96ba-156ceaceef03', NULL, NULL, CAST(N'2023-11-30T20:30:17.8054333+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[Teams] ([Id], [Name], [Description], [Location], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'21089e5e-6d4b-4405-96ba-156ceaceef03', N'Alpha', N'Where ther eis a wias sdjhlksdjf', N'Downtown', 0, NULL, NULL, CAST(N'2023-11-30T18:35:14.9598993+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Teams] ([Id], [Name], [Description], [Location], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'1d694ccb-64b8-477a-a114-6f17b0a61a01', N'Abu Bakkar', N'hwo arte', N'Pulwama', 0, NULL, NULL, CAST(N'2023-11-30T19:00:29.0029590+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Teams] ([Id], [Name], [Description], [Location], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8447357e-bf08-46bc-98d7-b78683c8454c', N'Mohammad Team', N'They are cool', N'UpTown', 0, NULL, NULL, CAST(N'2023-11-30T18:41:19.5982494+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', N'Rizwan Ahmad', 1, N'rizwan', N'rizwandar33@gmail.com', N'9697956788', N'$2a$11$TYYBxfFaSET3Oizd0CXEleNVtkdE7FEE.p60NpoAT13WT38X2OP5q', N'$2a$11$TYYBxfFaSET3Oizd0CXEle', N'', N'', 1, 1, 1, N'6b5e075d-9c2e-4731-b76f-b76871b6e292', N'0acb7a72-a85c-4736-9fa2-d1c4754ec309', CAST(N'2023-11-30T13:01:56.5494806+05:30' AS DateTimeOffset), CAST(N'2023-11-30T13:01:56.5494818+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'88a20fea-e7aa-46d2-9f4e-055aa2e5f494', N'abid', 1, N'logichubss2', N'logichubss+2@gmail.com', N'98798797', N'$2a$11$nlLYCrlHY/FbrPxWy8lWrOaMnoBYoE6PR3wJAz81WBqTcp3O0guqy', N'$2a$11$nlLYCrlHY/FbrPxWy8lWrO', N'', N'5498', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-11-30T16:04:31.2921664+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e0985d7f-d3a4-48b0-9bfe-26efa68e8c56', N'Faisal', 0, N'logichubss', N'logichubss@gmail.com', N'112223333', N'$2a$11$CPvk8n.ssSUvDyigAxIf1O3VT2b.6IJ.kHVJ0re12sfvdabZ/OFdO', N'$2a$11$CPvk8n.ssSUvDyigAxIf1O', N'', N'1080', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-11-30T13:15:20.2879910+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'0601cd4f-15bd-443b-a1f3-2a6996949994', N'sarfaraz', 1, N'logichubss1', N'logichubss+1@gmail.com', N'1111000000', N'$2a$11$a/eZD4UIOyWADDPb3.BjoOH.X2os5NRykZFSaKM/6NBfzOnQAXyLK', N'$2a$11$a/eZD4UIOyWADDPb3.BjoO', N'', N'18939', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-11-30T15:45:47.8753141+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'660914c2-b671-4d32-beb8-617682ceb2cc', N'Adil', 1, N'adil', N'logichubss+4@gmail.com', N'741851111', N'$2a$11$tuluNI8DYR4Mw8uSuqEWr.HxaRDruKqgJ.jjUf/V6rk6OYS.fcVpO', N'$2a$11$tuluNI8DYR4Mw8uSuqEWr.', N'', N'', 1, 2, 1, N'660914c2-b671-4d32-beb8-617682ceb2cc', N'660914c2-b671-4d32-beb8-617682ceb2cc', CAST(N'2023-11-30T17:22:12.2930448+05:30' AS DateTimeOffset), CAST(N'2023-11-30T17:25:14.1209690+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'b862986f-234e-4716-916b-805f7e390d2a', N'Musaib', 1, N'musaib', N'rizwandar33+333@gmail.com', N'1236985555', N'$2a$11$xSyUyMJvdoNiv3dFf1iS0Ozejl1pZ2KIDfkNLMZhgk7LMIlpq9OMa', N'$2a$11$xSyUyMJvdoNiv3dFf1iS0O', N'', N'', 1, 2, 1, N'b862986f-234e-4716-916b-805f7e390d2a', N'b862986f-234e-4716-916b-805f7e390d2a', CAST(N'2023-12-02T22:50:59.4235265+05:30' AS DateTimeOffset), CAST(N'2023-12-02T23:02:32.2724375+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'594f0759-4050-48fe-8d42-b8402ed239b0', N'sami', 1, N'logichubss3', N'logichubss+3@gmail.com', N'8825084050', N'$2a$11$h1WRplISly20wQ0VcU01LexoRY5H0zV74R.1DpGOietFjtuVabyc6', N'$2a$11$h1WRplISly20wQ0VcU01Le', N'', N'4333', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-11-30T16:05:48.7805879+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', N'faizan', 1, N'faizan', N'rizwandar33+22@gmail.com', N'09697956444', N'$2a$11$vYYJhebEnOa4Anv/csSdYep7JO3hN1R.4q7i2y2/8E7NKmnxkXPMm', N'$2a$11$vYYJhebEnOa4Anv/csSdYe', N'', N'896', 1, 2, 1, N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', N'bc4df8eb-a3cd-4948-ad6e-c85758de65db', CAST(N'2023-11-30T23:27:48.5628916+05:30' AS DateTimeOffset), CAST(N'2023-12-02T23:51:27.5663017+05:30' AS DateTimeOffset))
GO
ALTER TABLE [dbo].[AppealVerifications]  WITH CHECK ADD  CONSTRAINT [FK_AppealVerifications_Members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[AppealVerifications] CHECK CONSTRAINT [FK_AppealVerifications_Members_MemberId]
GO
ALTER TABLE [dbo].[AppealVerifications]  WITH CHECK ADD  CONSTRAINT [FK_AppealVerifications_TeamAssignments_TeamAssignmentId] FOREIGN KEY([TeamAssignmentId])
REFERENCES [dbo].[TeamAssignments] ([Id])
GO
ALTER TABLE [dbo].[AppealVerifications] CHECK CONSTRAINT [FK_AppealVerifications_TeamAssignments_TeamAssignmentId]
GO
ALTER TABLE [dbo].[DonationAppeals]  WITH CHECK ADD  CONSTRAINT [FK_DonationAppeals_PartnerSeekers_BeneficiaryId] FOREIGN KEY([BeneficiaryId])
REFERENCES [dbo].[PartnerSeekers] ([Id])
GO
ALTER TABLE [dbo].[DonationAppeals] CHECK CONSTRAINT [FK_DonationAppeals_PartnerSeekers_BeneficiaryId]
GO
ALTER TABLE [dbo].[Hobbies]  WITH CHECK ADD  CONSTRAINT [FK_Hobbies_PartnerSeekers_PartnerSeekerId] FOREIGN KEY([PartnerSeekerId])
REFERENCES [dbo].[PartnerSeekers] ([Id])
GO
ALTER TABLE [dbo].[Hobbies] CHECK CONSTRAINT [FK_Hobbies_PartnerSeekers_PartnerSeekerId]
GO
ALTER TABLE [dbo].[JobHistories]  WITH CHECK ADD  CONSTRAINT [FK_JobHistories_PartnerSeekers_PartnerSeekerId] FOREIGN KEY([PartnerSeekerId])
REFERENCES [dbo].[PartnerSeekers] ([Id])
GO
ALTER TABLE [dbo].[JobHistories] CHECK CONSTRAINT [FK_JobHistories_PartnerSeekers_PartnerSeekerId]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_Teams_TeamId]
GO
ALTER TABLE [dbo].[Members]  WITH CHECK ADD  CONSTRAINT [FK_Members_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Members] CHECK CONSTRAINT [FK_Members_Users_Id]
GO
ALTER TABLE [dbo].[PartnerSeekers]  WITH CHECK ADD  CONSTRAINT [FK_PartnerSeekers_Users_Id] FOREIGN KEY([Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[PartnerSeekers] CHECK CONSTRAINT [FK_PartnerSeekers_Users_Id]
GO
ALTER TABLE [dbo].[Proposals]  WITH CHECK ADD  CONSTRAINT [FK_Proposals_PartnerSeekers_RecieverId] FOREIGN KEY([RecieverId])
REFERENCES [dbo].[PartnerSeekers] ([Id])
GO
ALTER TABLE [dbo].[Proposals] CHECK CONSTRAINT [FK_Proposals_PartnerSeekers_RecieverId]
GO
ALTER TABLE [dbo].[Proposals]  WITH CHECK ADD  CONSTRAINT [FK_Proposals_PartnerSeekers_SenderId] FOREIGN KEY([SenderId])
REFERENCES [dbo].[PartnerSeekers] ([Id])
GO
ALTER TABLE [dbo].[Proposals] CHECK CONSTRAINT [FK_Proposals_PartnerSeekers_SenderId]
GO
ALTER TABLE [dbo].[Qualifications]  WITH CHECK ADD  CONSTRAINT [FK_Qualifications_PartnerSeekers_PartnerSeekerId] FOREIGN KEY([PartnerSeekerId])
REFERENCES [dbo].[PartnerSeekers] ([Id])
GO
ALTER TABLE [dbo].[Qualifications] CHECK CONSTRAINT [FK_Qualifications_PartnerSeekers_PartnerSeekerId]
GO
ALTER TABLE [dbo].[SocialMedia]  WITH CHECK ADD  CONSTRAINT [FK_SocialMedia_PartnerSeekers_PartnerSeekerId] FOREIGN KEY([PartnerSeekerId])
REFERENCES [dbo].[PartnerSeekers] ([Id])
GO
ALTER TABLE [dbo].[SocialMedia] CHECK CONSTRAINT [FK_SocialMedia_PartnerSeekers_PartnerSeekerId]
GO
ALTER TABLE [dbo].[TeamAssignments]  WITH CHECK ADD  CONSTRAINT [FK_TeamAssignments_DonationAppeals_AppealId] FOREIGN KEY([AppealId])
REFERENCES [dbo].[DonationAppeals] ([Id])
GO
ALTER TABLE [dbo].[TeamAssignments] CHECK CONSTRAINT [FK_TeamAssignments_DonationAppeals_AppealId]
GO
ALTER TABLE [dbo].[TeamAssignments]  WITH CHECK ADD  CONSTRAINT [FK_TeamAssignments_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[TeamAssignments] CHECK CONSTRAINT [FK_TeamAssignments_Teams_TeamId]
GO
ALTER TABLE [dbo].[TeamMembers]  WITH CHECK ADD  CONSTRAINT [FK_TeamMembers_Members_MemberId] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Members] ([Id])
GO
ALTER TABLE [dbo].[TeamMembers] CHECK CONSTRAINT [FK_TeamMembers_Members_MemberId]
GO
ALTER TABLE [dbo].[TeamMembers]  WITH CHECK ADD  CONSTRAINT [FK_TeamMembers_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([Id])
GO
ALTER TABLE [dbo].[TeamMembers] CHECK CONSTRAINT [FK_TeamMembers_Teams_TeamId]
GO
