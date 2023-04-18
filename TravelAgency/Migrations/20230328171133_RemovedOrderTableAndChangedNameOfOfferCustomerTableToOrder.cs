using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    public partial class RemovedOrderTableAndChangedNameOfOfferCustomerTableToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OffersCustomers_OfferCustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OffersCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OfferCustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OfferCustomerId",
                table: "Orders",
                newName: "OfferId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfCrewMmebers",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OfferId",
                table: "Orders",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Offers_OfferId",
                table: "Orders",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Offers_OfferId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OfferId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NumberOfCrewMmebers",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "Orders",
                newName: "OfferCustomerId");

            migrationBuilder.CreateTable(
                name: "OffersCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OfferId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfCrew = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffersCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OffersCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OffersCustomers_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OffersCustomers_OfferCustomerId",
                table: "Orders",
                column: "OfferCustomerId",
                principalTable: "OffersCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
