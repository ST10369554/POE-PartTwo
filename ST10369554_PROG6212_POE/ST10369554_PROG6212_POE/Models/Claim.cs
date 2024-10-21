using System.ComponentModel.DataAnnotations;

namespace ST10369554_PROG6212_POE.Models
{
    public class Claim
    {
        public int ClaimId { get; set; }

        [Required]
        public string LecturerId { get; set; }
        public string LecturerName { get; set; }
        public string LecturerSurname { get; set; }

        public string ManagerId { get; set; }
        public string ManegerName { get; set; }
        public string ManagerSurname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ClaimDate { get; set; }

        [Required]
        public decimal HoursWorked { get; set; }

        [Required]
        public string WorkType { get; set; }
        public string Programme { get; set; }
        public string ModuleCode { get; set; }
        public int Groups {  get; set; }
        public decimal HourlyRate { get; set; }
        public decimal Total {  get; set; }
        public decimal GrandTotal { get; set; }
        public string SupportingDocumentPath { get; set; }

        public int StatusId { get; set; }

        public string ManagerFeedback { get; set; }
    }

    }
