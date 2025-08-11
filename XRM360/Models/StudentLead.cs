namespace XRM360website.Models
{
    using System.ComponentModel.DataAnnotations;

    public enum ContactMethod { Email, Phone, WeChat }
    public enum StudyLevel { Undergraduate, Graduate, PhD, Certificate, ESL }
    public enum EnglishTestStatus { NotTaken, Scheduled, Taken }
    public enum LeadSource { Website, Referral, Social, Event, Other }

    public class StudentLead
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = default!;

        [EmailAddress, MaxLength(200)]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = default!;

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
        public StudyLevel StudyLevel { get; set; } = StudyLevel.Undergraduate;

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

        [MaxLength(60)]
        [Display(Name = "Budget Range (USD/year)")]
        public string? BudgetRangeUsd { get; set; }

        [Display(Name = "Lead Source")]
        public LeadSource Source { get; set; } = LeadSource.Website;

        [MaxLength(2000)]
        [Display(Name = "Additional Notes")]
        public string? Notes { get; set; }

        [MaxLength(64)]
        [Display(Name = "UTM Source")]
        public string? UtmSource { get; set; }

        [Display(Name = "Created (UTC)")]
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }

}
