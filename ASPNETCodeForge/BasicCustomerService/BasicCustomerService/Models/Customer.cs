using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonPropertyOrder(1)]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [JsonPropertyOrder(7)]
        public DateTime RegistrationDate { get; private set; } 
        [Required(ErrorMessage = "{0} is required")]
        [JsonPropertyOrder(8)]
        public CustomerStatus Status { get; set; } = CustomerStatus.Active;

        public Customer()
        {
            RegistrationDate = DateTime.Now;
        }
        [JsonPropertyOrder(9)]
        public List<Address> Addresses { get; set; } = new();
    }
}
