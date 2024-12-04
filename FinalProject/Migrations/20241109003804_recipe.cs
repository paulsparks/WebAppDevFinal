using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class recipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Author = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Author", "Date", "Description", "Name" },
                values: new object[] { 1, "Paul Sparks", new DateOnly(2024, 11, 8), "In a large wok, melt a spoonful of ghee and add thinly chopped chicken thigh. Once cooked, add 2 large eggs. After those are finished, add refrigerated white rice. Then, in order, add soy sauce, fish sauce, and gochujang. Make a hole in the center, add some more ghee, and fry up some minced garlic, sliced serrano peppers, and sliced shallots. Mix and cook for a short time, then incorporate into rice. Add dark soy sauce and shaoxing cooking wine. Turn off heat, then add MSG, sesame oil, and furikake rice seasoning. Mix well, and serve with sliced green onions on top.", "Chicken Fried Rice" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
