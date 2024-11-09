using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? Date { get; set; }
    public string? Author { get; set; }

    public string Slug =>
      Name?.Replace(" ", "-").ToLower() + "-" +
        Date?.Month + Date?.Day + Date?.Year;
  }
}