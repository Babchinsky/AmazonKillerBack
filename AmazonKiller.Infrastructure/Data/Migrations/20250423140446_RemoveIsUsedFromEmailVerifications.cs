using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonKiller.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsUsedFromEmailVerifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "EmailVerifications");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "EmailVerifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
