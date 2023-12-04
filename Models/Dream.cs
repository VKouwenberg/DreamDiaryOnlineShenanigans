using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models;

public class Dream //Movie
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }

    [Display(Name = "Date Added")]
    [DataType(DataType.Date)]
    public DateTime DateAdded { get; set; } //ReleaseDate

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Display(Name = "Sleep Quality")]
    public string? SleepQuality { get; set; } //Genre
    /*public decimal Price { get; set; }*/

    [Required]
    [StringLength(5)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    public string Visibility { get; set; } = string.Empty; //Rating
}