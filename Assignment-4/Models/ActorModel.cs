using System.ComponentModel.DataAnnotations;

namespace Assignment_4.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(100)]
        [Display(Name = "Birth City")]
        public string? BirthCity { get; set; }

        [StringLength(100)]
        [Display(Name = "Birth Country")]
        public string? BirthCountry { get; set; }

        [Range(20, 100, ErrorMessage = "Height must be between 20 and 100 inches")]
        public int? HeightInches { get; set; }

        [StringLength(1000)]
        public string? Biography { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [StringLength(10)]
        public string? Gender { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Net Worth must be positive")]
        public double? NetWorth { get; set; }
    }
}

