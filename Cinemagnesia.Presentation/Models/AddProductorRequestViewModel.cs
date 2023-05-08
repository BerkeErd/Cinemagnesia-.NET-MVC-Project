namespace Cinemagnesia.Presentation.Models
{
    public class AddProductorRequestViewModel
    {
        public string ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public DateTime FoundDate { get; set; }
    }
}
