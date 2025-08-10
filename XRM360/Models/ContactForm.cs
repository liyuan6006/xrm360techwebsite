using System.ComponentModel.DataAnnotations;

namespace XRM360website.Models
{
    public class ContactForm
    {
        [Required] public string Name { get; set; } = "";
        [Required, EmailAddress] public string Email { get; set; } = "";
        // Optional
        // Optional, allow international formats (+, spaces, hyphens, numbers)
        [RegularExpression(@"^\+?[0-9\s\-]{6,20}$", ErrorMessage = "Invalid phone number format.")]
        public string Phone { get; set; }
        public string? Subject { get; set; }

        [Required] public string Message { get; set; } = "";
    }
}
