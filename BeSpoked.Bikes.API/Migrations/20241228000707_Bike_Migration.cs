using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeSpoked.Bikes.API.Migrations
{
    /// <inheritdoc />
    public partial class Bike_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CUST_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CUST_ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purchase_Price = table.Column<double>(type: "float", nullable: false),
                    Sale_Price = table.Column<double>(type: "float", nullable: false),
                    Qty_On_Hand = table.Column<int>(type: "int", nullable: false),
                    Commission_Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "SalesPerson",
                columns: table => new
                {
                    SP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    terminationdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    manager = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPerson", x => x.SP_ID);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CUST_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    sellDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductsProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesPersonSP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerCUST_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_Sales_Customer_CustomerCUST_ID",
                        column: x => x.CustomerCUST_ID,
                        principalTable: "Customer",
                        principalColumn: "CUST_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_SalesPerson_SalesPersonSP_ID",
                        column: x => x.SalesPersonSP_ID,
                        principalTable: "SalesPerson",
                        principalColumn: "SP_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerCUST_ID",
                table: "Sales",
                column: "CustomerCUST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductsProductID",
                table: "Sales",
                column: "ProductsProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesPersonSP_ID",
                table: "Sales",
                column: "SalesPersonSP_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SalesPerson");
        }
    }
}
