using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace ToDoList.Migrations
{
    public partial class OnConfiguring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Item_Category_CategoryId", table: "Items");
            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Item_Category_CategoryId", table: "Items");
            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
