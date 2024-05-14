using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khandar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class apporder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnoymousDonors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnoymousDonors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AppealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Receipt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    AppPaymentStatus = table.Column<int>(type: "int", nullable: false),
                    RpOrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppPayments_AppOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "AppOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("26eabe54-0841-4afc-a659-6286cdbf7a3d"), new DateTimeOffset(new DateTime(2023, 12, 8, 0, 10, 8, 115, DateTimeKind.Unspecified).AddTicks(6124), new TimeSpan(0, 5, 30, 0, 0)), new Guid("bd4fecca-aa22-4cc2-aa40-4e8efad06963"), new DateTimeOffset(new DateTime(2023, 12, 8, 0, 10, 8, 115, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_AppPayments_OrderId",
                table: "AppPayments",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnoymousDonors");

            migrationBuilder.DropTable(
                name: "AppPayments");

            migrationBuilder.DropTable(
                name: "AppOrders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("30682788-0710-4f2a-9763-5ffe2686f26c"), new DateTimeOffset(new DateTime(2023, 12, 7, 18, 50, 7, 723, DateTimeKind.Unspecified).AddTicks(9738), new TimeSpan(0, 5, 30, 0, 0)), new Guid("58b0237b-6d14-42bd-acdf-a46f70125a3e"), new DateTimeOffset(new DateTime(2023, 12, 7, 18, 50, 7, 723, DateTimeKind.Unspecified).AddTicks(9749), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
