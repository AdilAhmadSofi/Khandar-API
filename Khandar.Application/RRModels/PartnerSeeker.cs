using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Khandar.Application.RRModels
{
    public class BasicProfileResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string FilePath { get; set; }= string.Empty;

        public string? AddressLine { get; set; }

        public string? Qualification { get; set; }

        public string? AadhaarNo { get; set; }
    }
    public class PartnerSeekerRequest
    {
        public Guid Id { get; set; }

        public string? Name { get; set; } = string.Empty;

        public string Parentage { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;

        public string? ContactNo { get; set; } = string.Empty;

        public Gender? Gender { get; set; }

        public string AadhaarNo { get; set; } = string.Empty;

        public string Caste { get; set; } = string.Empty;

        public DateTime? DOB { get; set; }

        public Religion Religion { get; set; }

        public Religious Religious { get; set; }

        public NativeLanguage NativeLanguage { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public string Occupation { get; set; } = string.Empty;

        public WorkingSector WorkingSector { get; set; }

        public AnnualIncome AnnualIncome { get; set; }

        public Disability Disability { get; set; }

        public Height Height { get; set; }

        public BodyType BodyType { get; set; }

        public Complexion Complexion { get; set; }

        public bool? HasBeard { get; set; } = false;

        public bool? DoesHijab { get; set; } = false;

        public FamilyStatus FamilyStatus { get; set; }

        public ParentStatus FatherStatus { get; set; }

        public ParentStatus MotherStatus { get; set; }

        public int? Brothers { get; set; }

        public int? BrothersMarried { get; set; }

        public int? Sisters { get; set; }

        public int? SistersMarried { get; set; }

        public ProfilePictureVisibilty ProfilePictureVisibilty { get; set; }

        public string? Description { get; set; } = string.Empty;

        public IFormFile? File { get; set; }
    }


    public class PartnerSeekerResponse : PartnerSeekerRequest
    {
        public string FilePath { get; set; } = string.Empty;

        public DateTimeOffset CreatedOn { get; set; }

    }

    public class PersonalInfoResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Parentage { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string ContactNo { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public string AadhaarNo { get; set; } = string.Empty;

        public string Caste { get; set; } = string.Empty;

        public string Age { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        public string FilePath { get; set; } = string.Empty;

        public NativeLanguage NativeLanguage { get; set; }

        
        public MaritalStatus MaritalStatus { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }


    public class FamilyInfoResponse
    {
        public Guid Id { get; set; }

        public FamilyStatus FamilyStatus { get; set; }

        public ParentStatus FatherStatus { get; set; }

        public ParentStatus MotherStatus { get; set; }

        public int? Brothers { get; set; }

        public int? BrothersMarried { get; set; }

        public int? Sisters { get; set; }

        public int? SistersMarried { get; set; }
    }

    public class ProfessionalInfoResponse
    {
        public Guid Id { get; set; }

        public string Occupation { get; set; } = string.Empty;

        public WorkingSector WorkingSector { get; set; }

        public AnnualIncome AnnualIncome { get; set; }

    }


    public class AppearanceInfoResponse
    {
        public Guid Id { get; set; }

        public Disability Disability { get; set; }

        public Height Height { get; set; }

        public BodyType BodyType { get; set; }

        public Complexion Complexion { get; set; }

    }

    public class ReligiousInfoResponse
    {
        public Guid Id { get; set; }

        public Religion Religion { get; set; }

        public Religious Religious { get; set; }

        public bool? HasBeard { get; set; } = false;

        public bool? DoesHijab { get; set; } = false;
    }

    
    public class PartnerSeekerVisibiltyRequest
    {
        public Guid Id { get; set; }
        public VisibilityLevel VisibilityLevel { get; set; }
    }


  

    public class PartnerSeekerPublicResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Caste { get; set; } = null!;

        public DateTime DOB { get; set; }

        public int Age { get; set; }

        public string Occupation { get; set; } = null!;

        public string Description { get; set; } = null!;

        public MaritalStatus MaritalStatus { get; set; }

        public NativeLanguage NativeLanguage { get; set; }

        public WorkingSector WorkingSector { get; set; }

        public Religion Religion { get; set; }

        public Gender Gender { get; set; }

        public string City { get; set; } = string.Empty;

        public string? FilePath { get; set; } = null;
    }

    public class ProposalInfoResponse: PartnerSeekerPublicResponse
    {

        public Guid ProposalId { get; set; }

        public Guid RecieverId { get; set; }

        public VisibilityLevel VisibilityLevel { get; set; }

        public ProposalStatus ProposalStatus { get; set; }

        public bool AllowChat { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string FilePath { get; set; } = null!;
    }

    public class BeneficiaryDetailsResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
        public string Parentage { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Caste { get; set; } = null!;

        public DateTime DOB { get; set; }

        public string Occupation { get; set; } = null!;

        public string Description { get; set; } = null!;

        public MaritalStatus MaritalStatus { get; set; }

        public NativeLanguage NativeLanguage { get; set; }

        public WorkingSector WorkingSector { get; set; }

        public Religion Religion { get; set; }

        public Religious Religious { get; set; }

        public Gender Gender { get; set; }

        public string City { get; set; } = string.Empty;

        public Disability Disability { get; set; } 

        public AnnualIncome AnnualIncome { get; set; } 

        public FamilyStatus FamilyStatus { get; set; } 

        public FamilyStatus FatherStatus { get; set; } 

        public FamilyStatus MotherStatus { get; set; } 
        public int Brothers { get; set; } 
        public int Sisters { get; set; } 
        public int BrothersMarried { get; set; } 
        public int SistersMarried { get; set; }
        public string AddressLine { get; set; } = string.Empty;
        public string Landmark { get; set; } = string.Empty;
        public string PinCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Qualification { get; set; } = string.Empty;


        public string FilePath { get; set; } = string.Empty;

    
    }
}
