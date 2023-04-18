using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    public partial class UpdateCrewModelHideIsBooker2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBooker",
                table: "Crews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBooker",
                table: "Crews",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
