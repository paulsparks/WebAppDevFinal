using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Data
{
  public class RecipesContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public RecipesContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
      _configuration = configuration;
    }

    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("MoviesContext"));
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Movie>().HasData(
        new Recipe
        {
          RecipeId = 1,
          Name = "Chicken Fried Rice",
          Description = "In a large wok, melt a spoonful of ghee and add thinly chopped chicken thigh. Once cooked, add 2 large eggs. After those are finished, add refrigerated white rice. Then, in order, add soy sauce, fish sauce, and gochujang. Make a hole in the center, add some more ghee, and fry up some minced garlic, sliced serrano peppers, and sliced shallots. Mix and cook for a short time, then incorporate into rice. Add dark soy sauce and shaoxing cooking wine. Turn off heat, then add MSG, sesame oil, and furikake rice seasoning. Mix well, and serve with sliced green onions on top.",
          Author = "Paul Sparks",
          Date = new DateOnly(2024, 11, 8)
        }
      );
    }
  }
}