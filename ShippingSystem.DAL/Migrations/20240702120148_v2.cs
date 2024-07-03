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
            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryPrice",
                table: "SpecialOffer",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                table: "SpecialOffer");
        }
    }
    /// <inheritdoc />
   
}
