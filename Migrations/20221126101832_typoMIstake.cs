using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class typoMIstake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "tbl_Order");

            migrationBuilder.DropColumn(
                name: "qunatity",
                table: "tbl_Order");

            migrationBuilder.AddColumn<DateTime>(
                name: "orderDate",
                table: "tbl_Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "quantity",
                table: "tbl_Order",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderDate",
                table: "tbl_Order");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "tbl_Order");

            migrationBuilder.AddColumn<DateTime>(
                name: "dateTime",
                table: "tbl_Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "qunatity",
                table: "tbl_Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
