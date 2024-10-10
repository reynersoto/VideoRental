using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMvcPruebaMosh.Migrations
{
    /// <inheritdoc />
    public partial class AddedInterCodeToNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InternalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalCode",
                table: "AspNetUsers");
        }
    }
}
