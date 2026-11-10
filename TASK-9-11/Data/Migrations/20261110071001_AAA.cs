using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TASK_8_11.Data.Migrations
{
    /// <inheritdoc />
    public partial class AAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_categories_CategoryId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_supply_SupplierId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_product_SupplierId",
                table: "Employee",
                newName: "IX_Employee_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_product_CategoryId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "product");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_SupplierId",
                table: "product",
                newName: "IX_product_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CategoryId",
                table: "product",
                newName: "IX_product_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_categories_CategoryId",
                table: "product",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_supply_SupplierId",
                table: "product",
                column: "SupplierId",
                principalTable: "supply",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
