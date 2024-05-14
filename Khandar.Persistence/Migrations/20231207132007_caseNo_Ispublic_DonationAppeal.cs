using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khandar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class caseNo_Ispublic_DonationAppeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CaseNo",
                table: "DonationAppeals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "DonationAppeals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("30682788-0710-4f2a-9763-5ffe2686f26c"), new DateTimeOffset(new DateTime(2023, 12, 7, 18, 50, 7, 723, DateTimeKind.Unspecified).AddTicks(9738), new TimeSpan(0, 5, 30, 0, 0)), new Guid("58b0237b-6d14-42bd-acdf-a46f70125a3e"), new DateTimeOffset(new DateTime(2023, 12, 7, 18, 50, 7, 723, DateTimeKind.Unspecified).AddTicks(9749), new TimeSpan(0, 5, 30, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseNo",
                table: "DonationAppeals");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "DonationAppeals");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("6de15661-4d77-4235-80ba-02d51ae32e23"), new DateTimeOffset(new DateTime(2023, 12, 3, 15, 52, 49, 872, DateTimeKind.Unspecified).AddTicks(6943), new TimeSpan(0, 5, 30, 0, 0)), new Guid("49399596-b617-4e16-b732-3e52cdf05fd0"), new DateTimeOffset(new DateTime(2023, 12, 3, 15, 52, 49, 872, DateTimeKind.Unspecified).AddTicks(6961), new TimeSpan(0, 5, 30, 0, 0)) });
        }
    }
}
