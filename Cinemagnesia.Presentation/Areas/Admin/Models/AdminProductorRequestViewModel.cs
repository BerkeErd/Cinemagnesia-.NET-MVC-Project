using Domain.Entities.Constants;

namespace Cinemagnesia.Presentation.Areas.Admin.Models
{
    public class AdminProductorRequestViewModel
    {
        public string Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
        public DateTime FoundDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
