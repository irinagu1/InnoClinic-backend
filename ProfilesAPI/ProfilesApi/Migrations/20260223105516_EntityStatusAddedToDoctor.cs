using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfilesApi.Migrations
{
    /// <inheritdoc />
    public partial class EntityStatusAddedToDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntityStatus",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityStatus",
                table: "Doctors");
        }
    }
}
