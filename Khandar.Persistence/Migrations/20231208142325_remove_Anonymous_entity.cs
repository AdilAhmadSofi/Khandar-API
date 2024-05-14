using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khandar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class remove_Anonymous_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnoymousDonors");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("38fc4a0f-b476-4dd0-9306-0d7f66ab0a77"), new DateTimeOffset(new DateTime(2023, 12, 8, 19, 53, 24, 940, DateTimeKind.Unspecified).AddTicks(889), new TimeSpan(0, 5, 30, 0, 0)), new Guid("cf24dc34-37b5-42cf-aa42-0a3dbecda0ac"), new DateTimeOffset(new DateTime(2023, 12, 8, 19, 53, 24, 940, DateTimeKind.Unspecified).AddTicks(900), new TimeSpan(0, 5, 30, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnoymousDonors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnoymousDonors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("d375ad27-371b-418d-8521-7ef422170e24"), new DateTimeOffset(new DateTime(2023, 12, 8, 14, 48, 17, 552, DateTimeKind.Unspecified).AddTicks(4576), new TimeSpan(0, 5, 30, 0, 0)), new Guid("89063e0a-a55c-4e9e-a8d5-ba1f27133c2b"), new DateTimeOffset(new DateTime(2023, 12, 8, 14, 48, 17, 552, DateTimeKind.Unspecified).AddTicks(4586), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
