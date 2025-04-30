using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicCustomerService.Models
{
    [NotMapped]
    public abstract class Person
    {
        [Required(ErrorMessage = "{0} is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public string? Document { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
