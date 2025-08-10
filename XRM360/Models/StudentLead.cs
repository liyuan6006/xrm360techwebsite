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
        public string FullName { get; set; } = default!;

        [Required, EmailAddress, MaxLength(200)]
        public string Email { get; set; } = default!;

        [Phone, MaxLength(40)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? WeChatId { get; set; }

        [Required]
        public ContactMethod PreferredContact { get; set; } = ContactMethod.Email;

        [Required]
        public StudyLevel StudyLevel { get; set; } = StudyLevel.Undergraduate;

        [MaxLength(150)]
        public string? IntendedMajor { get; set; }

        // Store as text initially; can normalize later (e.g., 2026-Fall)
        [MaxLength(40)]
        public string? TargetStartTerm { get; set; }

        [MaxLength(100)]
        public string? CurrentCity { get; set; }

        [MaxLength(100)]
        public string? CountryOfCitizenship { get; set; }

        public EnglishTestStatus EnglishStatus { get; set; } = EnglishTestStatus.NotTaken;

        [MaxLength(60)]
        public string? BudgetRangeUsd { get; set; } // e.g., "Under 20k", "20k–40k"

        public LeadSource Source { get; set; } = LeadSource.Website;

        [MaxLength(2000)]
        public string? Notes { get; set; }

        [MaxLength(64)]
        public string? UtmSource { get; set; } // optional tracking

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }

}
