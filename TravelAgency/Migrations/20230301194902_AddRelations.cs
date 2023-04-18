using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    public partial class AddRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferCustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "OffersCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "OffersCustomers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CruiseId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FleetId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkipperId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Crews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OfferCustomerId",
                table: "Orders",
                column: "OfferCustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OffersCustomers_CustomerId",
                table: "OffersCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OffersCustomers_OfferId",
                table: "OffersCustomers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CruiseId",
                table: "Offers",
                column: "CruiseId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_FleetId",
                table: "Offers",
                column: "FleetId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_SkipperId",
                table: "Offers",
                column: "SkipperId");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CustomerId",
                table: "Crews",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crews_Customers_CustomerId",
                table: "Crews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Cruises_CruiseId",
                table: "Offers",
                column: "CruiseId",
                principalTable: "Cruises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Fleets_FleetId",
                table: "Offers",
                column: "FleetId",
                principalTable: "Fleets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Skippers_SkipperId",
                table: "Offers",
                column: "SkipperId",
                principalTable: "Skippers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OffersCustomers_Customers_CustomerId",
                table: "OffersCustomers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OffersCustomers_Offers_OfferId",
                table: "OffersCustomers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OffersCustomers_OfferCustomerId",
                table: "Orders",
                column: "OfferCustomerId",
                principalTable: "OffersCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crews_Customers_CustomerId",
                table: "Crews");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Cruises_CruiseId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Fleets_FleetId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Skippers_SkipperId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_OffersCustomers_Customers_CustomerId",
                table: "OffersCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_OffersCustomers_Offers_OfferId",
                table: "OffersCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OffersCustomers_OfferCustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OfferCustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OffersCustomers_CustomerId",
                table: "OffersCustomers");

            migrationBuilder.DropIndex(
                name: "IX_OffersCustomers_OfferId",
                table: "OffersCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CruiseId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_FleetId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_SkipperId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Crews_CustomerId",
                table: "Crews");

            migrationBuilder.DropColumn(
                name: "OfferCustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "OffersCustomers");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "OffersCustomers");

            migrationBuilder.DropColumn(
                name: "CruiseId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "FleetId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "SkipperId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Crews");
        }
    }
}
