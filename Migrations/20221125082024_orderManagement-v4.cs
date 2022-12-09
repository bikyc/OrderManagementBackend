﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Migrations
{
    public partial class orderManagementv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "tbl_Customer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "tbl_Customer");
        }
    }
}
