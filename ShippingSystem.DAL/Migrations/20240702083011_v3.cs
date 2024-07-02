using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShippingSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialOffers",
                table: "SpecialOffers");

            migrationBuilder.RenameTable(
                name: "SpecialOffers",
                newName: "SpecialOffer");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SpecialOffer",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SpecialOffer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialOffer",
                table: "SpecialOffer",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a5dd3351-d3fe-4353-8bbc-f74d8f3056be", "AQAAAAIAAYagAAAAEFGjNNbfZ1CNlI5A9QJ1huIU7jxWL2UEbr1M6E1ABchK/bQLnAVpt49OGnHH8dmWrA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialOffer",
                table: "SpecialOffer");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SpecialOffer");

            migrationBuilder.RenameTable(
                name: "SpecialOffer",
                newName: "SpecialOffers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SpecialOffers",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialOffers",
                table: "SpecialOffers",
                column: "id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ffeb9282-deff-4524-909c-5c7d8e5014e1", "AQAAAAIAAYagAAAAELsq26NnBVhLea2rClddXj+vAYUch3UqHrA8ODNpBufBk37xEVBZ+yL++Spy2Rhrgg==" });
        }
    }
}
