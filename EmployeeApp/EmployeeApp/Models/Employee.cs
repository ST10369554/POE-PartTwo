using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email {  get; set; }

        [Required]
        [Phone]
        [StringLength(50)]
        public int Phone {  get; set; }

        [Required]
        public DateTime HireDate {  get; set; }
    }
}
