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
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_AspNetUsers_AccountId",
                table: "Permission");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Permission",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_AccountId",
                table: "Permission",
                newName: "IX_Permission_RoleId");

            migrationBuilder.AlterColumn<string>(
                name: "Governments",
                table: "DeliveryAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "NormalShippingCost",
                table: "City",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PickupShippingCost",
                table: "City",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "GovernmentID",
                table: "Branch",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

        
            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch",
                column: "GovernmentID",
                principalTable: "Government",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_AspNetRoles_RoleId",
                table: "Permission",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_AspNetRoles_RoleId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "NormalShippingCost",
                table: "City");

            migrationBuilder.DropColumn(
                name: "PickupShippingCost",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Permission",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Permission_RoleId",
                table: "Permission",
                newName: "IX_Permission_AccountId");

            migrationBuilder.AlterColumn<string>(
                name: "Governments",
                table: "DeliveryAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GovernmentID",
                table: "Branch",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Merchant");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RoleID" },
                values: new object[] { "316d8ab4-4cad-47b2-b2dd-498748e601cb", "AQAAAAIAAYagAAAAELEFXASaiNkpdjfrLtomS36FDVT9JkZbyG/KTYycPPy5aNhTgFo6GuU9cx464pCdBA==", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_Government_GovernmentID",
                table: "Branch",
                column: "GovernmentID",
                principalTable: "Government",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_AspNetUsers_AccountId",
                table: "Permission",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
