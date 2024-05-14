USE [KhandarDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[AppealVerifications]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[AppFiles]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[AppOrders]    Script Date: 12/8/2023 9:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppOrders](
	[Id] [uniqueidentifier] NOT NULL,
	[OrderId] [nvarchar](max) NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[AppealId] [uniqueidentifier] NOT NULL,
	[Receipt] [nvarchar](max) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[CreatedAt] [int] NOT NULL,
	[Currency] [nvarchar](max) NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_AppOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppPayments]    Script Date: 12/8/2023 9:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppPayments](
	[Id] [uniqueidentifier] NOT NULL,
	[TransactionId] [nvarchar](max) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Currency] [nvarchar](max) NOT NULL,
	[PaymentMethod] [int] NOT NULL,
	[AppPaymentStatus] [int] NOT NULL,
	[RpOrderId] [nvarchar](max) NOT NULL,
	[OrderId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_AppPayments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 12/8/2023 9:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonationAppeals]    Script Date: 12/8/2023 9:17:43 PM ******/
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
	[CaseNo] [nvarchar](max) NOT NULL,
	[IsPublic] [bit] NOT NULL,
 CONSTRAINT [PK_DonationAppeals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donations]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[Hobbies]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[JobHistories]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[Members]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[PartnerSeekers]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[Proposals]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[Qualifications]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[SocialMedia]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[TeamAssignments]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[TeamMembers]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[Teams]    Script Date: 12/8/2023 9:17:43 PM ******/
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
/****** Object:  Table [dbo].[Testimonials]    Script Date: 12/8/2023 9:17:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Testimonials](
	[Id] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[CreatedBy] [uniqueidentifier] NULL,
	[UpdatedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetimeoffset](7) NOT NULL,
	[UpdatedOn] [datetimeoffset](7) NULL,
 CONSTRAINT [PK_Testimonials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/8/2023 9:17:43 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231203102250_NewMigration', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231207132007_caseNo_Ispublic_DonationAppeal', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231207184008_apporder', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231208091817_contact-testimonial', N'7.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231208142325_remove_Anonymous_entity', N'7.0.10')
GO
INSERT [dbo].[Addresses] ([Id], [State], [City], [AddressLine], [Landmark], [PinCode], [IsNative], [EntityId], [IsDeleted], [Module], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e44e9ff9-8485-495e-8ca2-18871f02b39c', N'Jammu and Kashmir', N'Srinagar', N'Baghat', N'Dodganga Road', N'190005', 1, N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', 0, 0, N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', NULL, CAST(N'2023-12-07T12:11:21.0429116+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Addresses] ([Id], [State], [City], [AddressLine], [Landmark], [PinCode], [IsNative], [EntityId], [IsDeleted], [Module], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'68d6a5db-2ca3-45be-9d2f-82c7ca96d570', N'Jammu and Kashmir', N'Srinagar', N'Baghat', N'Dodganga Road', N'190005', 1, N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', 0, 0, N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', NULL, CAST(N'2023-12-07T12:30:59.0591284+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Addresses] ([Id], [State], [City], [AddressLine], [Landmark], [PinCode], [IsNative], [EntityId], [IsDeleted], [Module], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e026167e-827f-4862-b268-943e7592eb42', N'Jammu and Kashmir', N'Srinagar', N'Baghat', N'Dodganga Road', N'190005', 1, N'40836a35-b404-45b5-b64a-8403a60232e7', 0, 0, N'40836a35-b404-45b5-b64a-8403a60232e7', NULL, CAST(N'2023-12-07T12:14:54.3147299+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e93642e3-93be-41c8-b934-0521cedb5ac7', N'e01b2830-24a4-46ec-a112-67f229e3f760', N'6f7857ea-52af-49db-ba4b-7d4010bda8df', N'I thing this case is Geniune', 4, NULL, NULL, NULL, CAST(N'2023-12-08T13:51:07.4952232+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'3f7f0a8c-4730-492e-a98a-6b5ce0a61fbe', N'b9d09f91-f099-43f8-b265-ed5cc12905c8', N'42733740-8eda-4d7b-a2a0-625cd806b8fa', N'I thing this case is Geniune kjhgjkhij', 1, NULL, NULL, NULL, CAST(N'2023-12-08T13:44:22.1834188+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'1874af5a-4ff2-48d6-b908-9e1fa28f2806', N'1a364580-2286-4cc5-a14e-da516658944e', N'42733740-8eda-4d7b-a2a0-625cd806b8fa', N'I thing this case is Geniune', 1, NULL, NULL, NULL, CAST(N'2023-12-08T13:42:49.5460671+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'b6a59c4f-d5e6-42d2-952f-a5814e54f28e', N'62d4ccd8-bdf1-41e4-83a4-3984e11997f2', N'6f7857ea-52af-49db-ba4b-7d4010bda8df', N'I thing this case is Geniune kjhgjkhij', 1, NULL, NULL, NULL, CAST(N'2023-12-08T13:50:31.6630965+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'7c80bda3-9c47-4586-97d8-ea265f441db3', N'c563a277-9d0d-44fe-b3b9-b97354af2d2b', N'6f7857ea-52af-49db-ba4b-7d4010bda8df', N'I thing this case is Geniune', 1, NULL, NULL, NULL, CAST(N'2023-12-08T13:47:48.9636761+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'cb6f249b-f325-4a17-b458-f08ecfbc1062', N'adf74f99-0480-4c20-b021-b9391f0fca91', N'42733740-8eda-4d7b-a2a0-625cd806b8fa', N'I thing this case is Geniune', 4, NULL, NULL, NULL, CAST(N'2023-12-08T13:45:32.3194208+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8e02bc2b-2d67-4733-9552-f53768c24250', N'62d4ccd8-bdf1-41e4-83a4-3984e11997f2', N'e71a4d39-c60a-4afd-bf0d-a6fb6c79a354', N'Hi hello', 1, NULL, NULL, NULL, CAST(N'2023-12-07T12:56:38.8586373+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppealVerifications] ([Id], [MemberId], [TeamAssignmentId], [Feedback], [Remarks], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'96c12737-de6d-447b-ac03-fa6cae27601a', N'e01b2830-24a4-46ec-a112-67f229e3f760', N'e71a4d39-c60a-4afd-bf0d-a6fb6c79a354', N'I thing this case is Geniune', 4, NULL, NULL, NULL, CAST(N'2023-12-07T17:00:11.0515500+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'7019d4c8-da04-485b-bea5-4cc8f58f1f6a', 2, N'Files\Images\7de7af32-161a-448c-9de3-beb9c48519c4user.png', 0, N'40836a35-b404-45b5-b64a-8403a60232e7', N'40836a35-b404-45b5-b64a-8403a60232e7', NULL, CAST(N'2023-12-07T12:14:19.2611620+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'0eeac596-0615-4713-851d-59680ea7ecb3', 2, N'Files\Images\4d054d56-417d-4b3f-b066-2035106aca88tv1.png', 0, N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', NULL, CAST(N'2023-12-07T12:17:29.0347672+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'5648415e-8ad8-4f53-9683-832123defe05', 5, N'Files\Images\2fee4eb4-658c-4548-b37f-bbf22416bbf64K ULtra HD _ SAMSUNG UHD Demo׃ LED TV.mp4', 1, N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'40836a35-b404-45b5-b64a-8403a60232e7', NULL, CAST(N'2023-12-08T11:43:02.5264981+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'693af4c6-8375-4afb-803c-b9a38a7a757b', 5, N'Files\Images\eb9bb0cb-cc79-4cb2-83c0-ddf74128d27a4K ULtra HD _ SAMSUNG UHD Demo׃ LED TV.mp4', 1, N'0b28d057-ea91-4d29-9b17-4ee69f60779c', N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', NULL, CAST(N'2023-12-08T12:34:46.5921354+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppFiles] ([Id], [Module], [FilePath], [IsVideo], [EntityId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'd67d54be-777d-493c-af88-f7163844ef4e', 5, N'Files\Images\e83edc89-fdfd-4bd8-bc6a-0e71c0953f574K ULtra HD _ SAMSUNG UHD Demo׃ LED TV.mp4', 1, N'80d52569-af0e-43e6-af88-50be43c77dc2', N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', NULL, CAST(N'2023-12-07T12:31:19.7007281+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'bef8ac55-a180-47a1-aefa-02e779cc5e3b', N'order_N9micg10MWuVNw', N'bb32185a-065b-438c-aaa9-d9cc63df9b8f', N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'Khandar-16189', CAST(800000.00 AS Decimal(18, 2)), 1702024023, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T13:57:04.4281738+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8a0aa9da-90dc-407e-bd5d-1facd3eb4fa5', N'order_N9mlDpELzO4wAj', N'db9b747b-bb96-407b-b230-a57798ce52ec', N'0b28d057-ea91-4d29-9b17-4ee69f60779c', N'Khandar-18423', CAST(1200000.00 AS Decimal(18, 2)), 1702024171, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T13:59:32.0743193+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e5bb1125-cb03-475e-ba31-3f174bc9c898', N'order_N9mhDaoo797Ob8', N'3a91d7cc-5b3f-4f48-83a1-f3fadc0da303', N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'Khandar-4435', CAST(500000.00 AS Decimal(18, 2)), 1702023943, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T13:55:44.6506562+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'cc35972d-e035-4454-9d7f-40d4e9e2f12b', N'order_N9msNKcCzbrzAC', N'e01b2830-24a4-46ec-a112-67f229e3f760', N'80d52569-af0e-43e6-af88-50be43c77dc2', N'Khandar-51188', CAST(50000.00 AS Decimal(18, 2)), 1702024577, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T14:06:18.3092759+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'86602754-3760-4619-8b1c-5db01273d4da', N'order_N9mr4kOP09eIAc', N'e01b2830-24a4-46ec-a112-67f229e3f760', N'0b28d057-ea91-4d29-9b17-4ee69f60779c', N'Khandar-75049', CAST(2000000.00 AS Decimal(18, 2)), 1702024503, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T14:05:04.4850931+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'c75b2484-4f3b-4ec4-8517-87e8f3643b4c', N'order_N9muDbrnDVSmjs', N'c563a277-9d0d-44fe-b3b9-b97354af2d2b', N'0b28d057-ea91-4d29-9b17-4ee69f60779c', N'Khandar-97035', CAST(120000.00 AS Decimal(18, 2)), 1702024682, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T14:08:03.0104315+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'3386bacf-1fcf-4423-96c8-a589369608b2', N'order_N9mo2IZ0zqucKY', N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'Khandar-21802', CAST(1000000.00 AS Decimal(18, 2)), 1702024331, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T14:02:11.9200776+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'd5d9cd15-624f-4489-ad44-c08dfc4196f7', N'order_N9mtY62zfX2lt7', N'c563a277-9d0d-44fe-b3b9-b97354af2d2b', N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'Khandar-79974', CAST(1200000.00 AS Decimal(18, 2)), 1702024644, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T14:07:25.0741409+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'214b6ec0-245d-4b3a-8b6d-d026503c9938', N'order_N9mmQ2qG1BtiRn', N'd808e00a-7b15-49bf-8f5c-7ccf60509221', N'80d52569-af0e-43e6-af88-50be43c77dc2', N'Khandar-45455', CAST(1200000.00 AS Decimal(18, 2)), 1702024239, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T14:00:40.0557479+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'9eac8100-95ea-4c01-b0b9-dc15d1700273', N'order_N9molpfnFyegFI', N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', N'0b28d057-ea91-4d29-9b17-4ee69f60779c', N'Khandar-74556', CAST(500000.00 AS Decimal(18, 2)), 1702024372, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T14:02:53.6768205+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'6850d413-e356-48ef-ac93-e0494123bbf8', N'order_N9mfsKsuOCR3rs', N'6b5c86c3-f7c8-48d3-9d7f-b1165ab6e298', N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'Khandar-62763', CAST(1000000.00 AS Decimal(18, 2)), 1702023867, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T13:54:28.5644379+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8191d2ac-f86d-4099-9644-eed710eb0cea', N'order_N9mqKXARTM4FhY', N'e01b2830-24a4-46ec-a112-67f229e3f760', N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'Khandar-37393', CAST(1000000.00 AS Decimal(18, 2)), 1702024461, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T14:04:22.2172227+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppOrders] ([Id], [OrderId], [UserId], [AppealId], [Receipt], [TotalAmount], [CreatedAt], [Currency], [OrderStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'7a82de98-fec7-44d9-992d-ff71dcb215eb', N'order_N9mjjVuN1Qzfyi', N'f2da628b-5575-4986-a621-71060b86bdc1', N'0b28d057-ea91-4d29-9b17-4ee69f60779c', N'Khandar-67255', CAST(800000.00 AS Decimal(18, 2)), 1702024086, N'INR', 1, NULL, NULL, CAST(N'2023-12-08T13:58:07.4301623+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'3009a455-6563-4f7b-85db-3c8016eaa323', N'pay_N9moKKiA8PbVrQ', CAST(10000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mo2IZ0zqucKY', N'3386bacf-1fcf-4423-96c8-a589369608b2', NULL, NULL, CAST(N'2023-12-08T14:02:41.7071154+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'a39d2917-365a-43d5-b2c2-3e46cf2e8429', N'pay_N9msfRUhuCkyoo', CAST(500.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9msNKcCzbrzAC', N'cc35972d-e035-4454-9d7f-40d4e9e2f12b', NULL, NULL, CAST(N'2023-12-08T14:06:48.7412417+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8da1c4f7-9cf5-407e-ba76-5f5c59d864b4', N'pay_N9mk5tkid1Fj30', CAST(8000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mjjVuN1Qzfyi', N'7a82de98-fec7-44d9-992d-ff71dcb215eb', NULL, NULL, CAST(N'2023-12-08T13:58:43.3742867+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'964fa308-6225-4d22-9d69-73ccd9708ae9', N'pay_N9mha8zVBriJ8x', CAST(5000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mhDaoo797Ob8', N'e5bb1125-cb03-475e-ba31-3f174bc9c898', NULL, NULL, CAST(N'2023-12-08T13:56:26.3095198+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'95050257-b127-45d5-915d-89ea9140e2e0', N'pay_N9mmkgkr7twsKa', CAST(12000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mmQ2qG1BtiRn', N'214b6ec0-245d-4b3a-8b6d-d026503c9938', NULL, NULL, CAST(N'2023-12-08T14:01:13.6946906+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'd10b2100-51c9-41e7-9fc7-8b367fe34d37', N'pay_N9mjFrE1TiLDeo', CAST(8000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9micg10MWuVNw', N'bef8ac55-a180-47a1-aefa-02e779cc5e3b', NULL, NULL, CAST(N'2023-12-08T13:57:55.6024555+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'6271e2bb-3bb9-4da3-b954-9b48bc51d4c5', N'pay_N9mtqONADw5pqv', CAST(12000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mtY62zfX2lt7', N'd5d9cd15-624f-4489-ad44-c08dfc4196f7', NULL, NULL, CAST(N'2023-12-08T14:07:58.1713443+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'99e415f1-f2ea-4b33-8bd7-a3e2cfdb00a9', N'pay_N9mrk07uXTxQ6G', CAST(20000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mr4kOP09eIAc', N'86602754-3760-4619-8b1c-5db01273d4da', NULL, NULL, CAST(N'2023-12-08T14:05:57.5865756+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'73c7da14-d37a-4141-a73c-b15f65c3c0b9', N'pay_N9mqgB7f0opHT6', CAST(10000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mqKXARTM4FhY', N'8191d2ac-f86d-4099-9644-eed710eb0cea', NULL, NULL, CAST(N'2023-12-08T14:04:56.9177612+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8c259190-0765-4514-9a31-ba54e7b527e5', N'pay_N9mllGRxsvjzd2', CAST(12000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mlDpELzO4wAj', N'8a0aa9da-90dc-407e-bd5d-1facd3eb4fa5', NULL, NULL, CAST(N'2023-12-08T14:00:22.9494826+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'c9447269-c704-4cf7-9962-c9b2746d3023', N'pay_N9muX8qf8WIfVw', CAST(1200.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9muDbrnDVSmjs', N'c75b2484-4f3b-4ec4-8517-87e8f3643b4c', NULL, NULL, CAST(N'2023-12-08T14:08:36.3674449+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'70a214f5-cfeb-4689-ac0b-cb8da56f3ea9', N'pay_N9mpSG0rLojRbm', CAST(5000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9molpfnFyegFI', N'9eac8100-95ea-4c01-b0b9-dc15d1700273', NULL, NULL, CAST(N'2023-12-08T14:03:46.5208856+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[AppPayments] ([Id], [TransactionId], [Amount], [Currency], [PaymentMethod], [AppPaymentStatus], [RpOrderId], [OrderId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'2b75e1c9-8ae7-4989-93bc-f86f19e22c86', N'pay_N9mgAtZ4i0HtbC', CAST(10000.00 AS Decimal(18, 2)), N'INR', 1, 3, N'order_N9mfsKsuOCR3rs', N'6850d413-e356-48ef-ac93-e0494123bbf8', NULL, NULL, CAST(N'2023-12-08T13:54:59.5021827+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[DonationAppeals] ([Id], [BeneficiaryId], [Amount], [Description], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [CaseNo], [IsPublic]) VALUES (N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'40836a35-b404-45b5-b64a-8403a60232e7', 500000, N'a quick brown fox jumps over the lazy dog', 3, NULL, NULL, CAST(N'2023-12-08T11:43:02.4798103+05:30' AS DateTimeOffset), CAST(N'2023-12-08T13:52:17.0691898+05:30' AS DateTimeOffset), N'C-31073', 0)
INSERT [dbo].[DonationAppeals] ([Id], [BeneficiaryId], [Amount], [Description], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [CaseNo], [IsPublic]) VALUES (N'0b28d057-ea91-4d29-9b17-4ee69f60779c', N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', 50000, N'i am pooooooor', 3, NULL, NULL, CAST(N'2023-12-08T12:34:46.5740436+05:30' AS DateTimeOffset), CAST(N'2023-12-08T13:52:33.4435266+05:30' AS DateTimeOffset), N'C-45250', 1)
INSERT [dbo].[DonationAppeals] ([Id], [BeneficiaryId], [Amount], [Description], [DonationAppealStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn], [CaseNo], [IsPublic]) VALUES (N'80d52569-af0e-43e6-af88-50be43c77dc2', N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', 5000, N'a quick brown fox jumps over the lazy dog', 3, NULL, NULL, CAST(N'2023-12-07T12:31:19.6655888+05:30' AS DateTimeOffset), CAST(N'2023-12-08T11:40:03.4919502+05:30' AS DateTimeOffset), N'C-123', 0)
GO
INSERT [dbo].[JobHistories] ([Id], [JobTitle], [Company], [From], [To], [PartnerSeekerId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'46cee33a-7abb-4f64-8b1b-597b968051a1', N'deve', N'kdfl;k', CAST(N'2022-01-05T00:00:00.0000000' AS DateTime2), CAST(N'2021-11-07T00:00:00.0000000' AS DateTime2), N'e8218675-8364-45b8-b22a-bad58bc3a7d8', N'e8218675-8364-45b8-b22a-bad58bc3a7d8', NULL, CAST(N'2023-12-06T19:38:36.7631447+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'62d4ccd8-bdf1-41e4-83a4-3984e11997f2', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', 0, N'62d4ccd8-bdf1-41e4-83a4-3984e11997f2', NULL, CAST(N'2023-12-07T12:45:33.0382342+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e01b2830-24a4-46ec-a112-67f229e3f760', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', 0, N'e01b2830-24a4-46ec-a112-67f229e3f760', NULL, CAST(N'2023-12-07T12:41:36.8981675+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'adf74f99-0480-4c20-b021-b9391f0fca91', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', 0, N'adf74f99-0480-4c20-b021-b9391f0fca91', NULL, CAST(N'2023-12-07T12:39:11.2546112+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'c563a277-9d0d-44fe-b3b9-b97354af2d2b', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', 0, N'c563a277-9d0d-44fe-b3b9-b97354af2d2b', NULL, CAST(N'2023-12-07T12:42:47.8461142+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'1a364580-2286-4cc5-a14e-da516658944e', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', 0, N'1a364580-2286-4cc5-a14e-da516658944e', NULL, CAST(N'2023-12-07T12:46:42.9413539+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Members] ([Id], [Parentage], [DOB], [AadhaarNo], [MemberInvolvement], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'b9d09f91-f099-43f8-b265-ed5cc12905c8', N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), N'', 2, N'', 0, N'b9d09f91-f099-43f8-b265-ed5cc12905c8', NULL, CAST(N'2023-12-07T12:44:20.2108762+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[PartnerSeekers] ([Id], [Parentage], [AadhaarNo], [Caste], [DOB], [Religion], [Religious], [HasBeard], [DoesHijab], [NativeLanguage], [MaritalStatus], [Occupation], [WorkingSector], [AnnualIncome], [Disability], [Height], [BodyType], [Complexion], [FamilyStatus], [FatherStatus], [MotherStatus], [Brothers], [BrothersMarried], [Sisters], [SistersMarried], [ProfilePictureVisibilty], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', N'Mohammad', N'1111222233330001', N'Dar', CAST(N'2023-12-07T12:18:29.3787956' AS DateTime2), 1, 1, 0, 0, 2, 1, N'Developer', 3, 1, 2, 16, 2, 3, 3, 1, 1, 1, 0, 1, 1, 1, N'', 0, N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', CAST(N'2023-12-07T12:18:29.3788029+05:30' AS DateTimeOffset), CAST(N'2023-12-07T12:27:25.0306020+05:30' AS DateTimeOffset))
INSERT [dbo].[PartnerSeekers] ([Id], [Parentage], [AadhaarNo], [Caste], [DOB], [Religion], [Religious], [HasBeard], [DoesHijab], [NativeLanguage], [MaritalStatus], [Occupation], [WorkingSector], [AnnualIncome], [Disability], [Height], [BodyType], [Complexion], [FamilyStatus], [FatherStatus], [MotherStatus], [Brothers], [BrothersMarried], [Sisters], [SistersMarried], [ProfilePictureVisibilty], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', N'Mohammad', N'1111222233330001', N'Dar', CAST(N'2023-12-07T12:09:11.3070933' AS DateTime2), 1, 1, 0, 0, 3, 1, N'Developer', 1, 1, 1, 12, 3, 3, 2, 1, 2, 1, 1, 1, 1, 2, N'', 0, N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', CAST(N'2023-12-07T12:09:11.3071002+05:30' AS DateTimeOffset), CAST(N'2023-12-07T12:17:29.0119870+05:30' AS DateTimeOffset))
INSERT [dbo].[PartnerSeekers] ([Id], [Parentage], [AadhaarNo], [Caste], [DOB], [Religion], [Religious], [HasBeard], [DoesHijab], [NativeLanguage], [MaritalStatus], [Occupation], [WorkingSector], [AnnualIncome], [Disability], [Height], [BodyType], [Complexion], [FamilyStatus], [FatherStatus], [MotherStatus], [Brothers], [BrothersMarried], [Sisters], [SistersMarried], [ProfilePictureVisibilty], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'40836a35-b404-45b5-b64a-8403a60232e7', N'Mohammad', N'1111222233330001', N'Dar', CAST(N'2000-12-07T12:12:21.6740078' AS DateTime2), 1, 2, 0, 0, 1, 1, N'Developer', 2, 2, 1, 25, 2, 1, 1, 1, 1, 2, 2, 2, 2, 3, N'', 0, N'40836a35-b404-45b5-b64a-8403a60232e7', N'40836a35-b404-45b5-b64a-8403a60232e7', CAST(N'2023-12-07T12:12:21.6740144+05:30' AS DateTimeOffset), CAST(N'2023-12-07T12:25:20.5975181+05:30' AS DateTimeOffset))
INSERT [dbo].[PartnerSeekers] ([Id], [Parentage], [AadhaarNo], [Caste], [DOB], [Religion], [Religious], [HasBeard], [DoesHijab], [NativeLanguage], [MaritalStatus], [Occupation], [WorkingSector], [AnnualIncome], [Disability], [Height], [BodyType], [Complexion], [FamilyStatus], [FatherStatus], [MotherStatus], [Brothers], [BrothersMarried], [Sisters], [SistersMarried], [ProfilePictureVisibilty], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'fcf767c6-e935-47da-b9d3-942279204870', N'', N'', N'', CAST(N'2023-12-07T12:28:35.7247766' AS DateTime2), 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 1, N'', 0, N'fcf767c6-e935-47da-b9d3-942279204870', NULL, CAST(N'2023-12-07T12:28:35.7247822+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[PartnerSeekers] ([Id], [Parentage], [AadhaarNo], [Caste], [DOB], [Religion], [Religious], [HasBeard], [DoesHijab], [NativeLanguage], [MaritalStatus], [Occupation], [WorkingSector], [AnnualIncome], [Disability], [Height], [BodyType], [Complexion], [FamilyStatus], [FatherStatus], [MotherStatus], [Brothers], [BrothersMarried], [Sisters], [SistersMarried], [ProfilePictureVisibilty], [Description], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e8218675-8364-45b8-b22a-bad58bc3a7d8', N'', N'', N'', CAST(N'2023-12-06T19:32:20.1190612' AS DateTime2), 0, 0, 0, 0, 0, 0, N'', 0, 0, 0, 0, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 1, N'', 0, N'e8218675-8364-45b8-b22a-bad58bc3a7d8', NULL, CAST(N'2023-12-06T19:32:20.1190674+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[Qualifications] ([Id], [Name], [QualificationType], [Institution], [YearOfPassing], [PartnerSeekerId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e17e67c8-5e54-4948-91ad-4925cad04b66', N'MBA', 3, N'iust', N'2022', N'40836a35-b404-45b5-b64a-8403a60232e7', N'40836a35-b404-45b5-b64a-8403a60232e7', NULL, CAST(N'2023-12-07T12:14:39.5540850+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Qualifications] ([Id], [Name], [QualificationType], [Institution], [YearOfPassing], [PartnerSeekerId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'fa387246-0fda-4577-b270-8f3c8b7cf0f0', N'MBA', 1, N'iust', N'2022', N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', NULL, CAST(N'2023-12-07T12:10:54.0395073+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[TeamAssignments] ([Id], [AppealId], [TeamId], [TeamAssignStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'42733740-8eda-4d7b-a2a0-625cd806b8fa', N'd2ece6ef-c18b-47bf-be02-1b0ce87648c9', N'7d010b4e-42be-4e42-aca5-934c22153893', 2, NULL, NULL, CAST(N'2023-12-08T13:40:58.6414319+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamAssignments] ([Id], [AppealId], [TeamId], [TeamAssignStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'6f7857ea-52af-49db-ba4b-7d4010bda8df', N'0b28d057-ea91-4d29-9b17-4ee69f60779c', N'8974e0a1-b280-4531-bd52-0809f4a2c7ac', 2, NULL, NULL, CAST(N'2023-12-08T13:41:20.9982944+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamAssignments] ([Id], [AppealId], [TeamId], [TeamAssignStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e71a4d39-c60a-4afd-bf0d-a6fb6c79a354', N'80d52569-af0e-43e6-af88-50be43c77dc2', N'8974e0a1-b280-4531-bd52-0809f4a2c7ac', 2, NULL, NULL, CAST(N'2023-12-07T12:51:29.4481707+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'395415d2-b298-4613-ab80-1020ab9ee617', N'c563a277-9d0d-44fe-b3b9-b97354af2d2b', 3, 1, N'8974e0a1-b280-4531-bd52-0809f4a2c7ac', NULL, NULL, CAST(N'2023-12-07T12:48:22.4575379+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'891dc13a-276e-405f-98e2-56edc6cc2642', N'adf74f99-0480-4c20-b021-b9391f0fca91', 1, 1, N'7d010b4e-42be-4e42-aca5-934c22153893', NULL, NULL, CAST(N'2023-12-07T12:49:09.7028863+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'4dfd0da8-d39a-4f16-97bf-8469416c68ea', N'adf74f99-0480-4c20-b021-b9391f0fca91', 3, 2, N'649ec6d6-2b4b-4b98-a758-dbf594350296', NULL, NULL, CAST(N'2023-12-07T12:50:04.4318522+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'5d6645f5-5454-4d6f-a418-bdbcbccd0fc8', N'b9d09f91-f099-43f8-b265-ed5cc12905c8', 3, 2, N'649ec6d6-2b4b-4b98-a758-dbf594350296', NULL, NULL, CAST(N'2023-12-07T12:50:24.7323777+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'a87fe8bc-ac9a-4a3f-a98a-d56aa920100a', N'62d4ccd8-bdf1-41e4-83a4-3984e11997f2', 1, 1, N'649ec6d6-2b4b-4b98-a758-dbf594350296', NULL, NULL, CAST(N'2023-12-07T12:50:14.6744533+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'81b1a956-7565-42ab-bda7-d58d9eb6ac52', N'e01b2830-24a4-46ec-a112-67f229e3f760', 1, 1, N'8974e0a1-b280-4531-bd52-0809f4a2c7ac', NULL, NULL, CAST(N'2023-12-07T12:48:04.3764159+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'9d087acb-c209-4e53-8b12-e4db22eb2a14', N'62d4ccd8-bdf1-41e4-83a4-3984e11997f2', 3, 1, N'8974e0a1-b280-4531-bd52-0809f4a2c7ac', NULL, NULL, CAST(N'2023-12-07T12:47:49.0587930+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'84a4d7e8-64f1-479b-8064-f135be978b96', N'b9d09f91-f099-43f8-b265-ed5cc12905c8', 3, 2, N'7d010b4e-42be-4e42-aca5-934c22153893', NULL, NULL, CAST(N'2023-12-07T12:49:32.7849260+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[TeamMembers] ([Id], [MemberId], [MemberType], [MemberInvolvement], [TeamId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'44ae4935-8524-4f4b-afcc-f2516a92a031', N'1a364580-2286-4cc5-a14e-da516658944e', 3, 1, N'7d010b4e-42be-4e42-aca5-934c22153893', NULL, NULL, CAST(N'2023-12-07T12:49:23.5936301+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[Teams] ([Id], [Name], [Description], [Location], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8974e0a1-b280-4531-bd52-0809f4a2c7ac', N'Gamma', N'jlkajkl', N'kupwara', 0, NULL, NULL, CAST(N'2023-12-07T12:33:58.3349930+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Teams] ([Id], [Name], [Description], [Location], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'7d010b4e-42be-4e42-aca5-934c22153893', N'beta ', N'jlkajfklj', N'srinagar', 0, NULL, NULL, CAST(N'2023-12-07T12:33:40.2262120+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Teams] ([Id], [Name], [Description], [Location], [IsDeleted], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'649ec6d6-2b4b-4b98-a758-dbf594350296', N'Alpha', N'kljaklj', N'Downtown', 0, NULL, NULL, CAST(N'2023-12-07T12:33:17.1165332+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[Testimonials] ([Id], [Description], [IsActive], [CustomerId], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'becf8f2e-9f51-4c62-be4e-a1b9595ac615', N'Hi How are YOuo', 0, N'40836a35-b404-45b5-b64a-8403a60232e7', NULL, NULL, CAST(N'2023-12-08T15:04:41.2791438+05:30' AS DateTimeOffset), NULL)
GO
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', N'Rizwan Ahmad', 1, N'rizwan', N'rizwandar33@gmail.com', N'9697956788', N'$2a$11$TYYBxfFaSET3Oizd0CXEleNVtkdE7FEE.p60NpoAT13WT38X2OP5q', N'$2a$11$TYYBxfFaSET3Oizd0CXEle', N'', N'', 1, 1, 1, N'38fc4a0f-b476-4dd0-9306-0d7f66ab0a77', N'cf24dc34-37b5-42cf-aa42-0a3dbecda0ac', CAST(N'2023-12-08T19:53:24.9400889+05:30' AS DateTimeOffset), CAST(N'2023-12-08T19:53:24.9400900+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', N'Danish', 1, N'danish', N'logichubss+44@gmail.com', N'1233444454', N'$2a$11$2Zov6N4T8YrwvSy60jioZ.6p0m6lmV0Mvva6sVl78cRrBQPtE4PM6', N'$2a$11$2Zov6N4T8YrwvSy60jioZ.', N'', N'', 1, 2, 1, N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', N'8579fd5e-006e-4bb7-be5a-285fa612b6a2', CAST(N'2023-12-07T12:18:29.1362915+05:30' AS DateTimeOffset), CAST(N'2023-12-07T12:27:25.0306008+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'62d4ccd8-bdf1-41e4-83a4-3984e11997f2', N'Fayaz', 1, N'logichubss39', N'logichubss+39@gmail.com', N'122222239', N'$2a$11$TmFLu02XoJY5CVNv8dCDF.akkwsTCY4h9fXgx0JDNbsZsZtqE8ZBy', N'$2a$11$TmFLu02XoJY5CVNv8dCDF.', N'', N'3648', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-12-07T12:45:32.7928518+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', N'Sadaf', 2, N'sadaf', N'logichubss+45@gmail.com', N'8825080808', N'$2a$11$MJBu0nNp3C8IO7ipDEUey.xtmZyI9tkbreExpNCE5V61ob.I.zZ1y', N'$2a$11$MJBu0nNp3C8IO7ipDEUey.', N'', N'', 1, 2, 1, N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', N'43a5f32d-6ad5-4058-a91a-552a87e01e5f', CAST(N'2023-12-07T12:09:10.8819797+05:30' AS DateTimeOffset), CAST(N'2023-12-07T12:17:29.0119858+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e01b2830-24a4-46ec-a112-67f229e3f760', N'Sami', 1, N'logichubss36', N'logichubss+36@gmail.com', N'122222235', N'$2a$11$ZWjgM9yZFOXDp9GB2LMc0O1BBPv/rw6nlHRi90bpzZsoyMFwjN86O', N'$2a$11$ZWjgM9yZFOXDp9GB2LMc0O', N'', N'12633', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-12-07T12:41:36.6545699+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'40836a35-b404-45b5-b64a-8403a60232e7', N'bisma', 2, N'bisma', N'logichubss+33@gmail.com', N'9879879877', N'$2a$11$Z28dG05hMRk85pktFhjbfejB/GHF5312ughKKplQ03PmaX7hd0xMW', N'$2a$11$Z28dG05hMRk85pktFhjbfe', N'', N'', 1, 2, 1, N'40836a35-b404-45b5-b64a-8403a60232e7', N'40836a35-b404-45b5-b64a-8403a60232e7', CAST(N'2023-12-07T12:12:21.4211654+05:30' AS DateTimeOffset), CAST(N'2023-12-07T12:25:20.5975170+05:30' AS DateTimeOffset))
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'fcf767c6-e935-47da-b9d3-942279204870', N'Mehran', 1, N'mehran', N'logichubss+551@gmail.com', N'1122221111', N'$2a$11$pkemFbRScoQBEyMz84HB8.QdjJtQP88EceP1wgb8J37OejkTwrkSS', N'$2a$11$pkemFbRScoQBEyMz84HB8.', N'', N'', 1, 2, 1, N'fcf767c6-e935-47da-b9d3-942279204870', NULL, CAST(N'2023-12-07T12:28:35.4836603+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'adf74f99-0480-4c20-b021-b9391f0fca91', N'Sarfaraz', 1, N'logichubss35', N'logichubss+35@gmail.com', N'122222255', N'$2a$11$FfIix3ZVLzsb8WiK7AoGauragkkN7ihHWbG.Atu3kWs45Qhh0rPsa', N'$2a$11$FfIix3ZVLzsb8WiK7AoGau', N'', N'3045', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-12-07T12:39:11.0094528+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'c563a277-9d0d-44fe-b3b9-b97354af2d2b', N'Feroz', 1, N'logichubss37', N'logichubss+37@gmail.com', N'122222233', N'$2a$11$kGFklt/upqC76ddxhM3Edezpg252qPjGa5L7VE9p4THEtNVoWcQRW', N'$2a$11$kGFklt/upqC76ddxhM3Ede', N'', N'5496', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-12-07T12:42:47.5959015+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'e8218675-8364-45b8-b22a-bad58bc3a7d8', N'faizan', 1, N'faizan', N'logichubss+1@gmail.com', N'9966332211', N'$2a$11$vnRPaj8h5yzFMgz4wjJug.4Lcei1hZPYeKvwEnmIlMr79XmkNZuIi', N'$2a$11$vnRPaj8h5yzFMgz4wjJug.', N'', N'', 1, 2, 1, N'e8218675-8364-45b8-b22a-bad58bc3a7d8', NULL, CAST(N'2023-12-06T19:32:19.7271666+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'1a364580-2286-4cc5-a14e-da516658944e', N'Parvaiz', 1, N'logichubss40', N'logichubss+40@gmail.com', N'122222240', N'$2a$11$JuRv9ebzH.mb1/v.yFYlh.Jz8rNIaRs4tasbnQj/QM4OJLdqgX.ZK', N'$2a$11$JuRv9ebzH.mb1/v.yFYlh.', N'', N'14405', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-12-07T12:46:42.6864614+05:30' AS DateTimeOffset), NULL)
INSERT [dbo].[Users] ([Id], [Name], [Gender], [Username], [Email], [ContactNo], [Password], [Salt], [ResetCode], [ConfirmationCode], [IsEmailVerified], [UserRole], [UserStatus], [CreatedBy], [UpdatedBy], [CreatedOn], [UpdatedOn]) VALUES (N'b9d09f91-f099-43f8-b265-ed5cc12905c8', N'Zubair', 1, N'logichubss38', N'logichubss+38@gmail.com', N'122222234', N'$2a$11$SDwvUNi9bjhGnYJgjy7PEenNm.UvdVI7d7HjLNVlc2fuUuq6o2Uy6', N'$2a$11$SDwvUNi9bjhGnYJgjy7PEe', N'', N'1648', 1, 3, 1, N'764cbe0e-9b2e-4d95-af49-01b45a0fca5b', NULL, CAST(N'2023-12-07T12:44:19.9610619+05:30' AS DateTimeOffset), NULL)
GO
ALTER TABLE [dbo].[DonationAppeals] ADD  DEFAULT (N'') FOR [CaseNo]
GO
ALTER TABLE [dbo].[DonationAppeals] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsPublic]
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
ALTER TABLE [dbo].[AppPayments]  WITH CHECK ADD  CONSTRAINT [FK_AppPayments_AppOrders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[AppOrders] ([Id])
GO
ALTER TABLE [dbo].[AppPayments] CHECK CONSTRAINT [FK_AppPayments_AppOrders_OrderId]
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
ALTER TABLE [dbo].[Testimonials]  WITH CHECK ADD  CONSTRAINT [FK_Testimonials_Users_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Testimonials] CHECK CONSTRAINT [FK_Testimonials_Users_CustomerId]
GO
