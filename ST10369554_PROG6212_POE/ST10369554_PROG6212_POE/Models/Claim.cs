using System.ComponentModel.DataAnnotations;

namespace ST10369554_PROG6212_POE.Models
{
    public class Claim
    {
        public int Id { get; set; }

        [Required]
        public string LecturerId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; }

        [Required]
        public decimal HoursWorked { get; set; }

        [Required]
        public string WorkType { get; set; }

        public string SupportingDocumentPath { get; set; }

        public ClaimStatus Status { get; set; }

        public string ManagerComments { get; set; }
    }

    public enum ClaimStatus
    {
        Submitted,
        Pending,
        Approved,
        Rejected
    }

    public class Lecturer
    {
        public string LecturerId { get; set; }
        public string LecturerName { get; set; }
        public string LecturerSurname { get; set; }
    }

    public class Manager
    {
        public string ManagerId { get; set; }
        public string ManegerName { get; set; }
        public string ManagerSurname { get; set; }
    }
   


    }
