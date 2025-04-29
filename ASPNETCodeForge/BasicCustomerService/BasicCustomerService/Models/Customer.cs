using System.ComponentModel.DataAnnotations;

namespace BasicCustomerService.Models
{
    public enum CustomerStatus
    {
        Active,
        Inactive,
        Suspended
    }

    public class Customer : Person
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public DateTime RegistrationDate { get; private set; } 
        [Required(ErrorMessage = "{0} is required")]
        public CustomerStatus Status { get; set; } = CustomerStatus.Active;

        public Customer()
        {
            RegistrationDate = DateTime.Now;
        }
    }
}
