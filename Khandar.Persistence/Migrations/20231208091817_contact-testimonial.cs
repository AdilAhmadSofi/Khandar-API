using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khandar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class contacttestimonial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Testimonials_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("d375ad27-371b-418d-8521-7ef422170e24"), new DateTimeOffset(new DateTime(2023, 12, 8, 14, 48, 17, 552, DateTimeKind.Unspecified).AddTicks(4576), new TimeSpan(0, 5, 30, 0, 0)), new Guid("89063e0a-a55c-4e9e-a8d5-ba1f27133c2b"), new DateTimeOffset(new DateTime(2023, 12, 8, 14, 48, 17, 552, DateTimeKind.Unspecified).AddTicks(4586), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_CustomerId",
                table: "Testimonials",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("26eabe54-0841-4afc-a659-6286cdbf7a3d"), new DateTimeOffset(new DateTime(2023, 12, 8, 0, 10, 8, 115, DateTimeKind.Unspecified).AddTicks(6124), new TimeSpan(0, 5, 30, 0, 0)), new Guid("bd4fecca-aa22-4cc2-aa40-4e8efad06963"), new DateTimeOffset(new DateTime(2023, 12, 8, 0, 10, 8, 115, DateTimeKind.Unspecified).AddTicks(6141), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
