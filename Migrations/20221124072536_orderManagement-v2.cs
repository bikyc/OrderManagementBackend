using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class orderManagementv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Customer_tbl_Order_order_id",
                table: "tbl_Customer");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Customer_order_id",
                table: "tbl_Customer");

            migrationBuilder.DropColumn(
                name: "order_id",
                table: "tbl_Customer");

            migrationBuilder.AddColumn<int>(
                name: "customercust_id",
                table: "tbl_Order",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Order_customercust_id",
                table: "tbl_Order",
                column: "customercust_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Order_tbl_Customer_customercust_id",
                table: "tbl_Order",
                column: "customercust_id",
                principalTable: "tbl_Customer",
                principalColumn: "cust_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Order_tbl_Customer_customercust_id",
                table: "tbl_Order");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Order_customercust_id",
                table: "tbl_Order");

            migrationBuilder.DropColumn(
                name: "customercust_id",
                table: "tbl_Order");

            migrationBuilder.AddColumn<int>(
                name: "order_id",
                table: "tbl_Customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Customer_order_id",
                table: "tbl_Customer",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Customer_tbl_Order_order_id",
                table: "tbl_Customer",
                column: "order_id",
                principalTable: "tbl_Order",
                principalColumn: "order_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
