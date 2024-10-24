using System.ComponentModel.DataAnnotations;

namespace POE_Part2.Models
{
    public class LecturerClaim
    {
        [Required]
        public int ClaimId { get; set; }
        [Required]
        [Key]
        public int LecturerId { get; set; }
        public string LecturerName { get; set; }
        [Required]
        public double HoursWorked { get; set; }
        [Required]
        public double HourlyRate { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public string SupportingDocument { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}
