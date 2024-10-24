namespace PROG6212_POE_Part2.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string LecturerName { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public string SupportingDocument { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}
