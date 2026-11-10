using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TASK_8_11.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_product_ProductId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Supply_product_ProductId",
                table: "Supply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supply",
                table: "Supply");

            migrationBuilder.DropIndex(
                name: "IX_Supply_ProductId",
                table: "Supply");

            migrationBuilder.DropIndex(
                name: "IX_categories_ProductId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Supply");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "Supply",
                newName: "supply");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "supply",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_supply",
                table: "supply",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_SupplierId",
                table: "product",
                column: "SupplierId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_categories_CategoryId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_supply_SupplierId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_supply",
                table: "supply");

            migrationBuilder.DropIndex(
                name: "IX_product_CategoryId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_SupplierId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "supply");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "product");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "product");

            migrationBuilder.RenameTable(
                name: "supply",
                newName: "Supply");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Supply",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supply",
                table: "Supply",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Supply_ProductId",
                table: "Supply",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_ProductId",
                table: "categories",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_product_ProductId",
                table: "categories",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Supply_product_ProductId",
                table: "Supply",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id");
        }
    }
}
