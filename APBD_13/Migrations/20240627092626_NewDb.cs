using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_13.Migrations
{
    /// <inheritdoc />
    public partial class NewDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Reservation_Status",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation_Status", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Brands",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Brands", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Types",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Types", x => x.PK);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_vehicle_type = table.Column<int>(type: "int", nullable: false),
                    FK_vehicle_brand = table.Column<int>(type: "int", nullable: false),
                    model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    num_of_doors = table.Column<int>(type: "int", nullable: false),
                    num_of_seats = table.Column<int>(type: "int", nullable: false),
                    year_of_production = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Vehicles_Vehicle_Brands_FK_vehicle_brand",
                        column: x => x.FK_vehicle_brand,
                        principalTable: "Vehicle_Brands",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Vehicle_Types_FK_vehicle_type",
                        column: x => x.FK_vehicle_type,
                        principalTable: "Vehicle_Types",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    PK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_customer = table.Column<int>(type: "int", nullable: false),
                    FK_car = table.Column<int>(type: "int", nullable: false),
                    FK_reservation_status = table.Column<int>(type: "int", nullable: false),
                    from = table.Column<DateTime>(type: "datetime2", nullable: false),
                    to = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.PK);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_FK_customer",
                        column: x => x.FK_customer,
                        principalTable: "Customers",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Reservation_Status_FK_reservation_status",
                        column: x => x.FK_reservation_status,
                        principalTable: "Reservation_Status",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Vehicles_FK_car",
                        column: x => x.FK_car,
                        principalTable: "Vehicles",
                        principalColumn: "PK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FK_car",
                table: "Reservations",
                column: "FK_car");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FK_customer",
                table: "Reservations",
                column: "FK_customer");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FK_reservation_status",
                table: "Reservations",
                column: "FK_reservation_status");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FK_vehicle_brand",
                table: "Vehicles",
                column: "FK_vehicle_brand");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FK_vehicle_type",
                table: "Vehicles",
                column: "FK_vehicle_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Reservation_Status");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Vehicle_Brands");

            migrationBuilder.DropTable(
                name: "Vehicle_Types");
        }
    }
}
