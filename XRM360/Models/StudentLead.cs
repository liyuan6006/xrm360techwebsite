namespace XRM360website.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public enum ContactMethod { Email, Phone, WeChat }
    public enum StudyLevel
    {
        [Description("Community College")]
        CommunityCollege,

        [Description("Undergraduate - 4 year")]
        Undergraduate4Year,

        [Description("Graduate - Master's")]
        GraduateMasters,

        [Description("Graduate - PhD")]
        GraduatePhD
    }
    public enum EnglishTestStatus { NotTaken, Scheduled, Taken }
    public enum EnglishTestType { IELTS, TOEFL }
    public enum LeadSource { Website, Referral, Social, Event, Other }

    public class StudentLead
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = default!;

        [EmailAddress, MaxLength(200)]
        [Display(Name = "Email Address")]
        public string? Email { get; set; } = default!;

        [Required,Phone, MaxLength(40)]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Required,MaxLength(100)]
        [Display(Name = "WeChat ID")]
        public string? WeChatId { get; set; }

        [Required]
        [Display(Name = "Preferred Contact Method")]
        public ContactMethod PreferredContact { get; set; } = ContactMethod.Email;

        [Required]
        [Display(Name = "Intended Study Level")]
        public StudyLevel StudyLevel { get; set; } = StudyLevel.Undergraduate4Year;

        [MaxLength(150)]
        [Display(Name = "Intended Major")]
        public string? IntendedMajor { get; set; }

        [MaxLength(40)]
        [Display(Name = "Target Start Term")]
        public string? TargetStartTerm { get; set; }

        [MaxLength(100)]
        [Display(Name = "Current City")]
        public string? CurrentCity { get; set; }

        [MaxLength(100)]
        [Display(Name = "Country of Citizenship")]
        public string? CountryOfCitizenship { get; set; }

        [Display(Name = "English Test Status")]
        public EnglishTestStatus EnglishStatus { get; set; } = EnglishTestStatus.NotTaken;

        [MaxLength(2000)]
        [Display(Name = "Additional Notes")]
        public string? Notes { get; set; }

        [MaxLength(64)]
        [Display(Name = "UTM Source")]
        public string? UtmSource { get; set; }

        [Display(Name = "Created (UTC)")]
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;




        // Current high school name (text, optional)
        [MaxLength(150)]
        [Display(Name = "Current High School")]
        public string? CurrentHighSchool { get; set; }

        // GPA usually numeric (0.0–4.0), best stored as decimal
        [Range(0.0, 5.0)]
        [Display(Name = "Current GPA")]
        public decimal? CurrentGPA { get; set; }

        // Top 5 schools (text list, maybe comma-separated, optional)
        [MaxLength(500)]
        [Display(Name = "Target Schools (Top 5)")]
        public string? TargetSchools { get; set; }

        // Budget range (e.g., "$20k–$40k/year"), keep as string if textual ranges
        [MaxLength(100)]
        [Display(Name = "Target Budget Range")]
        public string? TargetBudget { get; set; }

        // Region (e.g., "East Coast", "California", "Midwest"), free text
        [MaxLength(100)]
        [Display(Name = "Target Region")]
        public string? TargetRegion { get; set; }

        // English test type (enum: TOEFL, IELTS, Duolingo, etc.)
        [Required]
        [Display(Name = "English Test Type")]
        public EnglishTestType EnglishType { get; set; } = EnglishTestType.TOEFL;

        // English test date — store as DateTime? for sorting/filtering
        [DataType(DataType.Date)]
        [Display(Name = "English Test Date")]
        public DateTime? EnglishTestDate { get; set; }

        // English test score — often numeric (0–120 TOEFL, 0–9 IELTS, etc.)
        [Range(0, 200)]
        [Display(Name = "English Test Score")]
        public int? EnglishScore { get; set; }


    }

}
