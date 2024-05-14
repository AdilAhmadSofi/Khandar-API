using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Khandar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_TeamId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("6de15661-4d77-4235-80ba-02d51ae32e23"), new DateTimeOffset(new DateTime(2023, 12, 3, 15, 52, 49, 872, DateTimeKind.Unspecified).AddTicks(6943), new TimeSpan(0, 5, 30, 0, 0)), new Guid("49399596-b617-4e16-b732-3e52cdf05fd0"), new DateTimeOffset(new DateTime(2023, 12, 3, 15, 52, 49, 872, DateTimeKind.Unspecified).AddTicks(6961), new TimeSpan(0, 5, 30, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("764cbe0e-9b2e-4d95-af49-01b45a0fca5b"),
                columns: new[] { "CreatedBy", "CreatedOn", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("6b5e075d-9c2e-4731-b76f-b76871b6e292"), new DateTimeOffset(new DateTime(2023, 11, 30, 13, 1, 56, 549, DateTimeKind.Unspecified).AddTicks(4806), new TimeSpan(0, 5, 30, 0, 0)), new Guid("0acb7a72-a85c-4736-9fa2-d1c4754ec309"), new DateTimeOffset(new DateTime(2023, 11, 30, 13, 1, 56, 549, DateTimeKind.Unspecified).AddTicks(4818), new TimeSpan(0, 5, 30, 0, 0)) });

            migrationBuilder.CreateIndex(
                name: "IX_Members_TeamId",
                table: "Members",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Teams_TeamId",
                table: "Members",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
