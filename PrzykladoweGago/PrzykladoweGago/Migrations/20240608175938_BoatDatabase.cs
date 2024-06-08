using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrzykladoweGago.Migrations
{
    /// <inheritdoc />
    public partial class BoatDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoatStandards",
                columns: table => new
                {
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatStandards", x => x.IdBoatStandard);
                });

            migrationBuilder.CreateTable(
                name: "ClientCategories",
                columns: table => new
                {
                    IdClientCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiscountPerc = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCategories", x => x.IdClientCategory);
                });

            migrationBuilder.CreateTable(
                name: "Sailboat",
                columns: table => new
                {
                    IdSailboat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sailboat", x => x.IdSailboat);
                    table.ForeignKey(
                        name: "FK_Sailboat_BoatStandards_IdBoatStandard",
                        column: x => x.IdBoatStandard,
                        principalTable: "BoatStandards",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdClientCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Clients_ClientCategories_IdClientCategory",
                        column: x => x.IdClientCategory,
                        principalTable: "ClientCategories",
                        principalColumn: "IdClientCategory",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    NumOfBoats = table.Column<int>(type: "int", nullable: false),
                    Fulfilled = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    CancelReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservation_BoatStandards_IdBoatStandard",
                        column: x => x.IdBoatStandard,
                        principalTable: "BoatStandards",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SailboatReservation",
                columns: table => new
                {
                    IdSailboat = table.Column<int>(type: "int", nullable: false),
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SailboatReservation", x => new { x.IdSailboat, x.IdReservation });
                    table.ForeignKey(
                        name: "FK_SailboatReservation_Reservation_IdReservation",
                        column: x => x.IdReservation,
                        principalTable: "Reservation",
                        principalColumn: "IdReservation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SailboatReservation_Sailboat_IdSailboat",
                        column: x => x.IdSailboat,
                        principalTable: "Sailboat",
                        principalColumn: "IdSailboat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BoatStandards",
                columns: new[] { "IdBoatStandard", "Level", "Name" },
                values: new object[] { 1, 1, "Test" });

            migrationBuilder.InsertData(
                table: "ClientCategories",
                columns: new[] { "IdClientCategory", "DiscountPerc", "Name" },
                values: new object[] { 1, 10.0, "Test" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Birthday", "Email", "IdClientCategory", "LastName", "Name", "Pesel" },
                values: new object[] { 1, new DateTime(2024, 6, 8, 19, 59, 38, 376, DateTimeKind.Local).AddTicks(79), "jankowalski@gmail.com", 1, "Kowalski", "Jan", "12345678901" });

            migrationBuilder.InsertData(
                table: "Sailboat",
                columns: new[] { "IdSailboat", "Capacity", "Description", "IdBoatStandard", "Name", "Price" },
                values: new object[] { 1, 10, "Test", 1, "Test", 100m });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "IdReservation", "CancelReason", "Capacity", "DateFrom", "DateTo", "Fulfilled", "IdBoatStandard", "IdClient", "NumOfBoats", "Price" },
                values: new object[] { 1, "Test", 1, new DateTime(2024, 6, 8, 19, 59, 38, 376, DateTimeKind.Local).AddTicks(217), new DateTime(2024, 6, 8, 19, 59, 38, 376, DateTimeKind.Local).AddTicks(221), false, 1, 1, 1, 1m });

            migrationBuilder.InsertData(
                table: "SailboatReservation",
                columns: new[] { "IdReservation", "IdSailboat" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_IdClientCategory",
                table: "Clients",
                column: "IdClientCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdBoatStandard",
                table: "Reservation",
                column: "IdBoatStandard");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdClient",
                table: "Reservation",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sailboat_IdBoatStandard",
                table: "Sailboat",
                column: "IdBoatStandard");

            migrationBuilder.CreateIndex(
                name: "IX_SailboatReservation_IdReservation",
                table: "SailboatReservation",
                column: "IdReservation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SailboatReservation");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Sailboat");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "BoatStandards");

            migrationBuilder.DropTable(
                name: "ClientCategories");
        }
    }
}
