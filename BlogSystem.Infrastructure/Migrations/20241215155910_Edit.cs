using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categories_Id",
                table: "Categories",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Id",
                table: "Categories");
        }
    }
}
