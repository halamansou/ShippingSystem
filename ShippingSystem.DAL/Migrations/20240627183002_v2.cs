using System;
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
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Branch");

            migrationBuilder.AddColumn<int>(
                name: "CitytId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedDate",
                table: "Order",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryPrice",
                table: "Order",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DeliverydDate",
                table: "Order",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GovernmentId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PaiedMoney",
                table: "Order",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivedMoney",
                table: "Order",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CreatedDate",
                table: "Branch",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Order_CitytId",
                table: "Order",
                column: "CitytId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_GovernmentId",
                table: "Order",
                column: "GovernmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_City_CitytId",
                table: "Order",
                column: "CitytId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Government_GovernmentId",
                table: "Order",
                column: "GovernmentId",
                principalTable: "Government",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_City_CitytId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Government_GovernmentId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CitytId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_GovernmentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CitytId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeliverydDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "GovernmentId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaiedMoney",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ReceivedMoney",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Branch");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Branch",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
