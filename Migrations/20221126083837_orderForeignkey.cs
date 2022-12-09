using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class orderForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Product_tbl_Order_order_id",
                table: "tbl_Product");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Product_order_id",
                table: "tbl_Product");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "tbl_Product");

            migrationBuilder.AddColumn<int>(
                name: "productProd_id",
                table: "tbl_Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Order_productProd_id",
                table: "tbl_Order",
                column: "productProd_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Order_tbl_Product_productProd_id",
                table: "tbl_Order",
                column: "productProd_id",
                principalTable: "tbl_Product",
                principalColumn: "Prod_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Order_tbl_Product_productProd_id",
                table: "tbl_Order");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Order_productProd_id",
                table: "tbl_Order");

            migrationBuilder.DropColumn(
                name: "productProd_id",
                table: "tbl_Order");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "tbl_Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Product_order_id",
                table: "tbl_Product",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Product_tbl_Order_order_id",
                table: "tbl_Product",
                column: "order_id",
                principalTable: "tbl_Order",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
