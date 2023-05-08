namespace Cinemagnesia.Presentation.Models
{
    public class UserProductorRequestViewModel
    {
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public DateTime FoundDate { get; set; }

        public string Message { get; set; } = "Başvurunuz alınmıştır lütfen e-posta adresinizi kontrol etmeyi unutmayın.";

        public int Code { get; set; } = 200;
    }
}
