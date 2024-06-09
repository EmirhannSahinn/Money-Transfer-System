using System.ComponentModel.DataAnnotations;

namespace money_transfer_system.Models
{
    public class TransferModel
    {
        [Required]
        public int FromCustomerId { get; set; }

        [Required]
        public int ToCustomerId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public float Amount { get; set; }
    }
}
