using System.ComponentModel.DataAnnotations;

namespace Assignment_4.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieID { get; set; }

        [Required]
        public int ActorID { get; set; }

        [Required(ErrorMessage = "Character Name is required")]
        [StringLength(100)]
        public string? CharacterName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Pay must be positive")]
        public double? Pay { get; set; }

        [Range(1, 1000, ErrorMessage = "Screentime must be between 1 and 1000 minutes")]
        public int? Screentime { get; set; }
    }
}

