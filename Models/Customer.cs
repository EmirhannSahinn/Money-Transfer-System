using System.ComponentModel.DataAnnotations;

namespace money_transfer_system.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [MaxLength(30)]
        public string? Name { get; set; }
       
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email format!")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "Money is required!")]
        public float Money { get; set; }
    }
}
