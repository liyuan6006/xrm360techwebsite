namespace XRM360website.Models
{
    public class SmtpOptions
    {
        public string Host { get; set; } = "";
        public int Port { get; set; } = 587;
        public string User { get; set; } = "";
        public string Pass { get; set; } = "";
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public bool UseStartTls { get; set; } = true;
    }
}
