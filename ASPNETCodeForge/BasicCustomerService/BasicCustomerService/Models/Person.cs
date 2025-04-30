using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BasicCustomerService.Models
{
    [NotMapped]
    public abstract class Person
    {
        [Required(ErrorMessage = "{0} is required.")]
        [JsonPropertyOrder(2)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [JsonPropertyOrder(3)]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [JsonPropertyOrder(4)]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [JsonPropertyOrder(5)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        [JsonPropertyOrder(6)]
        public string? Document { get; set; }

    }
}
