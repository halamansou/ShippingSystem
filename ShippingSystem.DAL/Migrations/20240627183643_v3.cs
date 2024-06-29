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
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_PaymentType_PaymentTypeId",
                table: "PaymentType");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingType_ShippingType_ShippingTypeId",
                table: "ShippingType");

            migrationBuilder.DropIndex(
                name: "IX_ShippingType_ShippingTypeId",
                table: "ShippingType");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_PaymentTypeId",
                table: "PaymentType");

            migrationBuilder.DropColumn(
                name: "ShippingTypeId",
                table: "ShippingType");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                table: "PaymentType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShippingTypeId",
                table: "ShippingType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                table: "PaymentType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShippingType_ShippingTypeId",
                table: "ShippingType",
                column: "ShippingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_PaymentTypeId",
                table: "PaymentType",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_PaymentType_PaymentTypeId",
                table: "PaymentType",
                column: "PaymentTypeId",
                principalTable: "PaymentType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingType_ShippingType_ShippingTypeId",
                table: "ShippingType",
                column: "ShippingTypeId",
                principalTable: "ShippingType",
                principalColumn: "Id");
        }
    }
}
