using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGiversWeb.Models
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Skills { get; set; }

        public string Availability { get; set; }
    }
}