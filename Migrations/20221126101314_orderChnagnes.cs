using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class orderChnagnes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderName",
                table: "tbl_Order");

            migrationBuilder.AddColumn<decimal>(
                name: "qunatity",
                table: "tbl_Order",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "totalPrice",
                table: "tbl_Order",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "qunatity",
                table: "tbl_Order");

            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "tbl_Order");

            migrationBuilder.AddColumn<string>(
                name: "orderName",
                table: "tbl_Order",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
