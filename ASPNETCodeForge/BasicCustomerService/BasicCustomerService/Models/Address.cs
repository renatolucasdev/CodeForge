using System.ComponentModel.DataAnnotations;

namespace BasicCustomerService.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? Street { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? City { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? State { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? ZipCode { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? Country { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public int PersonId { get; set; }// Foreign key
        public Person? Person { get; set; } // Navigation property
    }
}
