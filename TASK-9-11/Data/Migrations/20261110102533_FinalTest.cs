using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TASK_8_11.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_categories_CategoryId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_supply_SupplierId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_SupplierId",
                table: "products",
                newName: "IX_products_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CategoryId",
                table: "products",
                newName: "IX_products_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_supply_SupplierId",
                table: "products",
                column: "SupplierId",
                principalTable: "supply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_supply_SupplierId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_products_SupplierId",
                table: "Employee",
                newName: "IX_Employee_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_products_CategoryId",
                table: "Employee",
                newName: "IX_Employee_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_categories_CategoryId",
                table: "Employee",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_supply_SupplierId",
                table: "Employee",
                column: "SupplierId",
                principalTable: "supply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
