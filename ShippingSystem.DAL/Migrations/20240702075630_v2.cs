using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ffeb9282-deff-4524-909c-5c7d8e5014e1", "AQAAAAIAAYagAAAAELsq26NnBVhLea2rClddXj+vAYUch3UqHrA8ODNpBufBk37xEVBZ+yL++Spy2Rhrgg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94d2c9da-56f5-4400-9f22-355e4ef8ac7e", "AQAAAAIAAYagAAAAEFY5eboD8FO1bvnGtZ5JZsSrqSn42d35LHp/vmxDq13LLa7laVJrvxLEjEATQpBE1A==" });
        }
    }
}
