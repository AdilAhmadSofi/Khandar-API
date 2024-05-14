using AutoMapper;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;


namespace Khandar.Application.MapperProfile;

public sealed class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<LoginRequest, User>();
        CreateMap<User, LoginResponse>();
        CreateMap<SignUpRequest, User>();
        CreateMap<User, SignUpResponse>();
        CreateMap<AdminSignUpRequest, User>();
    }
}

public sealed class AddressProfile : Profile
{
    public AddressProfile()
    {
        CreateMap<AddressRequest, Address>();
        CreateMap<Address, AddressResponse>();
    }
}

public sealed class PartnerSeekerProfile : Profile
{
    public PartnerSeekerProfile()
    {
        CreateMap<PartnerSeekerRequest, PartnerSeeker>();
        CreateMap<PartnerSeeker, PartnerSeekerResponse>();
        CreateMap<PartnerSeekerVisibiltyRequest, PartnerSeeker>();
    }
}


public sealed class MemberProfile : Profile
{
    public MemberProfile()
    {
        CreateMap<MemberRequest, Member>();
        CreateMap<Member, MemberResponse>();
    }
}


public sealed class HobbyProfile : Profile
{
    public HobbyProfile()
    {
        CreateMap<HobbyRequest, Hobby>();
        CreateMap<Hobby, HobbyResponse>();
    }
}


public sealed class JobHistoryProfile : Profile
{
    public JobHistoryProfile()
    {
        CreateMap<JobHistoryRequest, JobHistory>();
        CreateMap<JobHistory, JobHistoryResponse>();
    }
}


public sealed class SocialMediaProfile : Profile
{
    public SocialMediaProfile()
    {
        CreateMap<SocialMediaRequest, SocialMedia>();
        CreateMap<SocialMedia, SocialMediaResponse>();
    }
}


public sealed class QualificationProfile : Profile
{
    public QualificationProfile()
    {
        CreateMap<QualificationRequest, Qualification>();
        CreateMap<Qualification, QualificationResponse>();
    }
}


public sealed class ProposalProfile : Profile
{
    public ProposalProfile()
    {
        CreateMap<Proposal, ProposalResponse>();
        CreateMap<ProposalUpdateRequest, Proposal>();
    }
}


public sealed class DonationProfile : Profile
{
    public DonationProfile()
    {
        CreateMap<DonationRequest, Donation>();
        CreateMap<Donation, DonationResponse>();
    }
}



public sealed class DonationAppealProfile : Profile
{
    public DonationAppealProfile()
    {
        CreateMap<DonationAppealRequest, DonationAppeal>();
        CreateMap<DonationAppeal, DonationAppealResponse>();
    }
}

public sealed class TeamAssignmentProfile : Profile
{
    public TeamAssignmentProfile()
    {
        CreateMap<TeamAssignmentRequest, TeamAssignment>();
        CreateMap<TeamAssignment, TeamAssignmentResponse>();
    }
}


public sealed class TeamProfile : Profile
{
    public TeamProfile()
    {
        CreateMap<TeamRequest, Team>();
        CreateMap<Team, TeamResponse>();
    }
}


public sealed class TeamMemberProfile:Profile
{
    public TeamMemberProfile()
    {
        CreateMap<TeamMemberRequest, TeamMember>();
        CreateMap<TeamMember, TeamMemberResponse>();
    }
}


public sealed class AppealVerificationProfile : Profile
{
    public AppealVerificationProfile()
    {
        CreateMap<AppealVerificationRequest, AppealVerification>();
        CreateMap<AppealVerification, AppealVerificationResponse>();
    }
}


public sealed class PartnerPreferenceProfile : Profile
{
    public PartnerPreferenceProfile()
    {
        CreateMap<PartnerPreferenceRequest, PartnerPreference>();
        CreateMap<PartnerPreference, PartnerPreferenceResponse>();
    }
}


public sealed class PaymentProfile : Profile
{
    public PaymentProfile()
    {
        CreateMap<AppOrderRequest, AppOrder>();
        CreateMap<AppOrder, AppOrderResponse>();
    }
}

public sealed class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactRequest, Contact>();
        CreateMap<Contact, ContactResponse>();
    }
}


