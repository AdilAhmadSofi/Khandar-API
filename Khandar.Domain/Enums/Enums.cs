using System.ComponentModel.DataAnnotations;

namespace Khandar.Domain.Enums
{
    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
        Other = 3
    }

    public enum UserRole
    {
        Admin = 1,
        PartnerSeeker = 2,
        Member = 3
    }

    public enum UserStatus
    {
        Active = 1,
        InActive = 2,
    }

    public enum AppOrderStatus
    {
        Created = 1,
        Attempted = 2,
        Paid = 3
    }

    public enum PaymentMethod
    {
        Card = 1,
        UPI = 2,
        NetBanking = 3,
        Wallet = 4,
        //EMI = 5
    }


    public enum AppPaymentStatus
    {
        Created = 1,
        Authorized = 2,
        Captured = 3,
        Failed = 4
    }


    public enum RpRefundStatus
    {
        Pending = 1,
        Processed = 2,
        Failed = 3
    }



    public enum Module
    {
        User = 1,
        PartnerSeeker = 2,
        Member = 3,
        Benificiary = 4,
        Guest = 5,
        Donation = 5
    }

    public enum DonationAppealStatus
    {
        Pending = 1,
        Processing = 2,
        Approved = 3,
        Rejected = 4,
        Cancelled = 5,
        Waiting = 6,
        Completed = 7,
        Verified = 8
    }

    public enum Religion
    {
        MuslimSunni = 1,

        MuslimShia = 2,

        Sikhism = 3,

        Hinduism = 4,

        Christian = 5,
    }

    public enum Religious
    {
        [Display(Name = "Very Religious")]
        VeryReligious = 1,

        [Display(Name = "Moderate Religious")]
        ModerateReligious = 2,

        [Display(Name = "Not Very Religious")]
        NotVeryReligious = 3,

        [Display(Name = "Not Religious")]
        NotReligious = 4,
    }

    public enum FamilyStatus
    {
        [Display(Name = "Middle Class")]
        MiddleClass = 1,

        Affluent = 2,

        [Display(Name = "Upper Middle Class")]
        UpperMiddleClass = 3,

        [Display(Name = "Lower Middle Class")]
        LowerMiddleClass = 4,

        [Display(Name = "Poor Family")]
        PoorFamily = 5,


        [Display(Name = "Prefer Not To Say")]
        PreferNotToSay = 6
    }

    public enum NativeLanguage
    {
        Kashmiri = 1,
        Urdu = 2,
        English = 3,
        Dogri = 4,
        Pahari = 5,
        Gojri = 6,
        Sindhi = 7,
        Balti = 8,
        Shina = 9,
        Punjabi = 10,
        Hindi = 11,
        Ladaki = 12,
        Other = 13,
    }

    public enum ProfileFor
    {
        Self = 1,
        Brother = 2,
        Son = 3,
        Daughter = 4,
        Sister = 5,
        Friend = 6,
        Relative = 7
    }

    public enum BodyType
    {
        Slim = 1,
        Average = 2,
        Athletic = 3,
        Fat = 4,
        Other = 5,
    }

    public enum Disability
    {
        None = 1,

        [Display(Name = "Mentally Challenged From Birth")]
        MentallyChallengedFromBirth = 2,

        [Display(Name = "Physical Abnormality Affecting Only Looks")]
        PhysicalAbnormalityAffectingOnlyLooks = 3,


        [Display(Name = "Physical Abnormality Affecting Bodily Fuction")]
        PhysicalAbnormalityAffectingBodilyFunction = 4,


        [Display(Name = " Physically Challenged Due To Accindent")]
        PhysicallyChallengedDueToAccindent = 5,

        [Display(Name = " Defects On Vital Organs")]
        DefectsOnVitalOrgans = 6,

        [Display(Name = " Physically Challenged From Birth")]
        PhysicallyChallengedFromBirth = 7

    }

    public enum Complexion
    {
        [Display(Name = "Very Fair")]
        VeryFair = 1,

        Fair = 2,

        Dark = 3,

        Brown = 4,

        Wheatish = 5,
        
        Others = 6
    }

    public enum Occupation
    {
        None = 0,
        Doctor = 1,
        Engineer = 2,
        Teacher = 3,
        Nurse = 4,
        Programmer = 5,
        Artist = 6,
        Chef = 7,
        PoliceOfficer = 8,
        Firefighter = 9,
        Lawyer = 10,
        Accountant = 11,
        Scientist = 12,
        Architect = 13,
        Musician = 14,
        Writer = 15,
        Electrician = 16,
        Carpenter = 17,
        Plumber = 18,
        Farmer = 19,
        Mechanic = 20,
        Police = 21,
        Clerk = 22,
        Student = 23,
        Technician = 24,
        SocialWorker = 25,
        Imam = 26,
        SalesPerson = 27,
        Journalist = 28,
        HairDresser = 29,
        Driver = 30,
        BussinesMan = 31,
        Beautician = 32,
        Other = 33,
    }

    public enum WorkingSector
    {
        Government = 1,
        Private = 2,
        SelfEmployed = 3,
        Bussiness = 4,
        NotWorking = 5,
        Other = 6,
    }

    public enum AnnualIncome
    {
        [Display(Name = "Below 1 Lakh")]
        BelowLac = 1,

        [Display(Name = "1 Lakh - 2 Lakh")]
        LacTo2Lac = 2,

        [Display(Name = "2.5 Lakh - 5 Lakh")]
        From2LacTo5Lac = 3,

        [Display(Name = "5 Lakh - 10 Lakh")]
        From5LacTo10Lac = 4,

        [Display(Name = "Above 10 Lakh")]
        Above10lac = 5,

        [Display(Name = "Prefer not to say")]
        PreferNotToSay = 6,

        None = 7
    }

    public enum Height
    {
        [Display(Name = "4 feet 0 inches")]
        FourFeet = 0,

        [Display(Name = "4 feet 1 inch")]
        FourFeet1Inch = 1,

        [Display(Name = "4 feet 2 inches")]
        FourFeet2Inches = 2,

        [Display(Name = "4 feet 3 inches")]
        FourFeet3Inches = 3,

        [Display(Name = "4 feet 4 inches")]
        FourFeet4Inches = 4,

        [Display(Name = "4 feet 5 inches")]
        FourFeet5Inches = 5,

        [Display(Name = "4 feet 6 inches")]
        FourFeet6Inches = 6,

        [Display(Name = "4 feet 7 inches")]
        FourFeet7Inches = 7,

        [Display(Name = "4 feet 8 inches")]
        FourFeet8Inches = 8,

        [Display(Name = "4 feet 9 inches")]
        FourFeet9Inches = 9,

        [Display(Name = "4 feet 10 inches")]
        FourFeet10Inches = 10,

        [Display(Name = "4 feet 11 inches")]
        FourFeet11Inches = 11,

        [Display(Name = "5 feet 0 inches")]
        FiveFeet = 12,

        [Display(Name = "5 feet 1 inch")]
        FiveFeet1Inch = 13,

        [Display(Name = "5 feet 2 inches")]
        FiveFeet2Inches = 14,

        [Display(Name = "5 feet 3 inches")]
        FiveFeet3Inches = 15,

        [Display(Name = "5 feet 4 inches")]
        FiveFeet4Inches = 16,

        [Display(Name = "5 feet 5 inches")]
        FiveFeet5Inches = 17,

        [Display(Name = "5 feet 6 inches")]
        FiveFeet6Inches = 18,

        [Display(Name = "5 feet 7 inches")]
        FiveFeet7Inches = 19,

        [Display(Name = "5 feet 8 inches")]
        FiveFeet8Inches = 20,

        [Display(Name = "5 feet 9 inches")]
        FiveFeet9Inches = 21,

        [Display(Name = "5 feet 10 inches")]
        FiveFeet10Inches = 22,

        [Display(Name = "5 feet 11 inches")]
        FiveFeet11Inches = 23,

        [Display(Name = "6 feet 0 inches")]
        SixFeet0Inches = 24,

        [Display(Name = "6 feet 1 inches")]
        SixFeet1Inches = 25,

        [Display(Name = "6 feet 2 inches")]
        SixFeet2Inches = 26,

        [Display(Name = "6 feet 3 inches")]
        SixFeet3Inches = 27,

        [Display(Name = "6 feet 4 inches")]
        SixFeet4Inches = 28,

        [Display(Name = "6 feet 5 inches")]
        SixFeet5Inches = 29,

        [Display(Name = "6 feet 6 inches")]
        SixFeet6Inches = 30,
    }

    public enum Hobbies
    {
        None = 0,
        Reading = 1,
        Writing = 2,
        Painting = 3,
        Cooking = 4,
        Gardening = 5,
        Hiking = 6,
        Swimming = 7,
        Photography = 8,
        PlayingMusic = 9,
        Dancing = 10,
        Fishing = 11,
        Cycling = 12,
        Traveling = 13,
        BirdWatching = 14,
        Gaming = 15,
        Yoga = 16,
        Chess = 17,
        Sculpting = 18,
        Woodworking = 19,
        Knitting = 20,
        CollectingCoins = 21,
        Astronomy = 22,
        Surfing = 23,
        Skiing = 24,
        Origami = 25,
        Baking = 26,
        Pottery = 27,
        Billiards = 28,
        Camping = 29,
        AutoRepair = 30,
        Calligraphy = 31,
        ModelBuilding = 32,
        BirdKeeping = 33,
        Antiquing = 34,
        Volunteering = 35,
        Running = 36,
        TableTennis = 37,
        ScubaDiving = 38,
        Meditation = 39,
        HorsebackRiding = 40,
        Archery = 41,
        Juggling = 42,
        WineTasting = 43,
        KiteFlying = 44,
        Rowing = 45,
        Stargazing = 46,
        Beekeeping = 47,
        CrosswordPuzzles = 48,
        StandUpComedy = 49,
        ArmWrestling = 50,
    }

    public enum QualificationType
    {
        Other = 0,
        HighSchool = 1,
        Diploma = 2,
        Bachelor = 3,
        Masters = 4,
        Doctorate = 5,
        Certificate = 6,
    }

    public enum ParentStatus
    {
        Employed = 1,
        Bussiness = 2,
        Retired = 3,

        [Display(Name = "Not Employed")]
        NotEmployed = 4,

        PassedAway = 5,

        HomeMaker = 6
    }

    public enum MaritalStatus
    {
        UnMarried = 1,
        Married = 2,
        Divorced = 3,
        Widowed = 4
    }

    public enum PaymentMode
    {
        Cash = 1,
        Card = 2,
        Cheque = 3,
        UPI = 4,
        [Display(Name = "Mobile Banking")]
        MobileBanking = 5,
        Other = 6,

    }

    public enum SocialMedia
    {
        Facebook = 1,
        LinkedIn = 2,
        Instagram = 3,
        Twitter = 4,
        Pinterest = 5,
        Youtube = 6,
    }

    public enum ProposalStatus
    {
        Pending = 1,
        Accepted = 2,
        Rejected = 3,
        Cancelled = 4,
    }

    public enum ProfilePictureVisibilty
    {
        OnlyMe = 1,
        OnlyFriends = 2,
        Everyone = 3,
    }

    public enum VisibilityLevel
    {
        [Display(Name = "Level One")]
        Level1 = 1,

        [Display(Name = "Level Two")]
        Level2 = 2,
    }

    public enum TeamLevel
    {
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
    }

    public enum MemberInvolvement
    {
        VerySerious = 1,
        Serious = 2,
        Moderate = 3,
        NonSerious = 4
    }

    public enum MemberType
    {
        Leader = 1,
        CoLeader = 2,
        Member = 3
    }

    public enum TeamAssignStatus
    {
        Pending = 1,
        Assigned = 2,
        Rejected = 3,
        Cancelled = 4,
    }

    public enum Remarks
    {
        Genuine = 1,
        Moderate = 2,
        Fraud = 3,
        Accepted = 4,
        Rejected = 5,
    }


    public enum AgeGroup
    {


    }
}
