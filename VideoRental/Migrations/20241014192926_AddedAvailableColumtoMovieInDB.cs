using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMvcPruebaMosh.Migrations
{
    /// <inheritdoc />
    public partial class AddedAvailableColumtoMovieInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "NumberAvailable",
                table: "Movies",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberAvailable",
                table: "Movies");
        }
    }
}
