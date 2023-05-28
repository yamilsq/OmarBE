using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rent_a_car_be.Migrations
{
    /// <inheritdoc />
    public partial class addongfuelquantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelQuantity",
                table: "CarInspection",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelQuantity",
                table: "CarInspection");
        }
    }
}
