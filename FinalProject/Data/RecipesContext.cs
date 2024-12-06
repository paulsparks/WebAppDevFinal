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
      => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("RecipesContext"));
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Recipe>().HasData(
        new Recipe
        {
          RecipeId = 1,
          Name = "Chicken Fried Rice",
          Description = "In a large wok, melt a spoonful of ghee and add thinly chopped chicken thigh. Once cooked, add 2 large eggs. After those are finished, add refrigerated white rice. Then, in order, add soy sauce, fish sauce, and gochujang. Make a hole in the center, add some more ghee, and fry up some minced garlic, sliced serrano peppers, and sliced shallots. Mix and cook for a short time, then incorporate into rice. Add dark soy sauce and shaoxing cooking wine. Turn off heat, then add MSG, sesame oil, and furikake rice seasoning. Mix well, and serve with sliced green onions on top.",
          Author = "Paul Sparks",
          Date = new DateOnly(2024, 11, 8),
          ImagePath = "/images/fried-rice.jpg"
        },
        new Recipe
        {
          RecipeId = 2,
          Name = "Cacio E Pepe",
          Description = "Begin boiling noodles per package instructions. While they're boiling, toast a good amount of peppercorns. Once those are fragrant, pour them into an empty pepper grinder. Grind into a large saucepan with walls. Pour some boiling pasta water into the saucepan and reduce, adding more water when it goes low. Grate a good amount of pecorino romano, and place in large mixing bowl. Once noodles are a few minutes away from being done, transfer them to the pepper water and finish the boil, timing the noodles being done with the pepper water being fully boiled off. Turn off heat. Add pasta water from the original noodle pot into the cheese bowl and stir, adding more water until it creates a velvety cheese sauce. Add the cheese sauce to the pan, stir in, and serve.",
          Author = "Paul Sparks",
          Date = new DateOnly(2024, 12, 3),
          ImagePath = "/images/cacio-e-pepe.jpg"
        },
        new Recipe
        {
          RecipeId = 3,
          Name = "Chicken Noodle Soup",
          Description = "In a large pot, add one part chicken stock (homemade recommended but store-bought is okay) and one or two parts water, then turn on the heat. Mince garlic, slice shallots, and cut up any other vegetables you'd like in the soup. Prepare lots of cooked chicken, preferably torn from a rotisserie chicken. Add vegetables, salt, pepper, and a dash of olive oil to the simmering broth. Cook until vegetables are soft, adding water when needed. Add noodles and begin boiling. A few minutes before the noodles are done, add the chicken to the pot. Reduce to a light simmer until the noodles are done, and serve.",
          Author = "Paul Sparks",
          Date = new DateOnly(2024, 12, 3),
          ImagePath = "/images/chicken-noodle-soup.jpg"
        }
      );
    }
  }
}