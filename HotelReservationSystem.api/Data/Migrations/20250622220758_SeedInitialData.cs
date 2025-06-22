using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelReservationSystem.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RoomTypes",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3422), true, "Free Wi-Fi", 0, null },
                    { 2, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3502), true, "Air Conditioning", 0, null },
                    { 3, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3504), true, "Flat-screen TV", 0, null },
                    { 4, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3506), true, "Mini-bar", 0, null },
                    { 5, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3507), true, "In-room Safe", 0, null },
                    { 6, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3509), true, "Coffee & Tea Maker", 0, null },
                    { 7, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3510), true, "Pool Access", 0, null },
                    { 8, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3569), true, "Gym Access", 0, null },
                    { 9, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3571), true, "Room Service", 0, null },
                    { 10, 0, new DateTime(2025, 6, 23, 1, 7, 56, 75, DateTimeKind.Local).AddTicks(3572), true, "Balcony", 0, null }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "IsActive", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2025, 6, 23, 1, 7, 56, 76, DateTimeKind.Local).AddTicks(1420), "A cozy room perfect for a single traveler.", true, "Standard Single", 0, null },
                    { 2, 0, new DateTime(2025, 6, 23, 1, 7, 56, 76, DateTimeKind.Local).AddTicks(1446), "A comfortable room with two single beds.", true, "Standard Double", 0, null },
                    { 3, 0, new DateTime(2025, 6, 23, 1, 7, 56, 76, DateTimeKind.Local).AddTicks(1448), "A spacious room with a queen-sized bed and premium amenities.", true, "Deluxe Queen", 0, null },
                    { 4, 0, new DateTime(2025, 6, 23, 1, 7, 56, 76, DateTimeKind.Local).AddTicks(1450), "An elegant room featuring a king-sized bed and enhanced space.", true, "Deluxe King", 0, null },
                    { 5, 0, new DateTime(2025, 6, 23, 1, 7, 56, 76, DateTimeKind.Local).AddTicks(1452), "A large room with a separate living area and king-sized bed.", true, "Junior Suite", 0, null },
                    { 6, 0, new DateTime(2025, 6, 23, 1, 7, 56, 76, DateTimeKind.Local).AddTicks(1454), "Our most luxurious suite with multiple rooms and exclusive services.", true, "Presidential Suite", 0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "RoomTypes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);
        }
    }
}
