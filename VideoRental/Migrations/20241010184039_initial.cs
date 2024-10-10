using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMvcPruebaMosh.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "MembershipTypeId",
                table: "Customers",
                newName: "MembershipTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers",
                newName: "IX_Customers_MembershipTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypesId",
                table: "Customers",
                column: "MembershipTypesId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypesId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "MembershipTypesId",
                table: "Customers",
                newName: "MembershipTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_MembershipTypesId",
                table: "Customers",
                newName: "IX_Customers_MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
