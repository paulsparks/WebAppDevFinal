using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
  public class Movie
  {
    public int MovieId { get; set; }
    public string? Name { get; set; }
    public int? Year { get; set; }
    public int? Rating { get; set; }

    [Required(ErrorMessage = "Please enter a genre.")]
    public string GenreId { get; set; }
    public Genre Genre { get; set; }

    public string Slug =>
      Name?.Replace(" ", "-").ToLower() + "-" +
        Year?.ToString();
  }
}