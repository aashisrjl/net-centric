using System.ComponentModel.DataAnnotations;

namespace Assignment_4.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title can't be empty")]
        [StringLength(100)]
        public string? Title { get; set; }

        [Range(0, 10, ErrorMessage = "Rating must be between 0 and 10")]
        public double? Rating { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be positive")]
        public double? Budget { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Gross must be positive")]
        public double? Gross { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Genre can't be empty")]
        [StringLength(50)]
        public string? Genre { get; set; }

        [Range(1, 500, ErrorMessage = "Runtime must be between 1 and 500 minutes")]
        public int? Runtime { get; set; }

        [StringLength(1000)]
        public string? Summary { get; set; }
    }
}

