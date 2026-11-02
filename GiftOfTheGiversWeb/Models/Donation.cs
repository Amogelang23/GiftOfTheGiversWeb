using System;
using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversWeb.Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DonorName { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Currency { get; set; } = "ZAR";

        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}