using System.ComponentModel.DataAnnotations;

namespace MyNewMvc.Models;

public class MusicModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title Is Required")]
    [StringLength(20, ErrorMessage = "Title must be less than 20 char")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Desc Is Required")]
    [StringLength(200, ErrorMessage = "Title must be less than 200 char")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Singer Is Required")]
    public string? Singer { get; set; }

    [Required(ErrorMessage = "Year of Release Is Required")]
    [Range(2000, 2025, ErrorMessage = "Year of Release must be between 2000 and 2025")]
    public string? YearOfRelease { get; set; }

    [Required(ErrorMessage = "Duration Is Required")]
    // [RegularExpression(@"^\d{1,2}: \d{2}$", ErrorMessage = "Duration must be in the format MM:SS")]
    public string? Duration { get; set; } // Duration in minutes

    
}
