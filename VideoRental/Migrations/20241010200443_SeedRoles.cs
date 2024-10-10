using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMvcPruebaMosh.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
           INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3abb1e6d-36f3-4f29-9ef4-e746f711c368', N'guest@reinervideoclub.com', N'GUEST@REINERVIDEOCLUB.COM', N'guest@reinervideoclub.com', N'GUEST@REINERVIDEOCLUB.COM', 1, N'AQAAAAIAAYagAAAAEClWm1pFArBFCsgrTwweP4K9fKDD/FJvVO09QA1DAStQhhejuSCn9QHSaNX4QpKTZA==', N'55FVRPRBHP6IA3V34SSJAC4X7L6P2XIY', N'c518ab33-808b-4844-b4a7-5862017c9bbc', NULL, 0, 0, NULL, 1, 0)
           INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'54fc3db7-ed0b-4a41-95fc-bcf7a9ef0c5c', N'admin@reinervideoclub.com', N'ADMIN@REINERVIDEOCLUB.COM', N'admin@reinervideoclub.com', N'ADMIN@REINERVIDEOCLUB.COM', 1, N'AQAAAAIAAYagAAAAEJlnzC6Lq+1j5FIguCV3USW54Ry/kMrRl22Phjherz7jYm/eKOQ/l/kXiH3qyhF/3A==', N'FJVW2S5ODTSQ5DU3GSSMSLOTYUBN75L4', N'e61a40fb-2045-4e80-819b-071638cafcd5', NULL, 0, 0, NULL, 1, 0)


            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'df696c9b-fa26-4f46-b2b1-ad753ea50361', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'54fc3db7-ed0b-4a41-95fc-bcf7a9ef0c5c', N'df696c9b-fa26-4f46-b2b1-ad753ea50361')
");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
