using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace resturant.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    homeLocation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Supplying",
                columns: table => new
                {
                    SupplyingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    supplyingNumber = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    supplyingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    goodsName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplying", x => x.SupplyingId);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    phoneNumber = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ManagerId);
                    table.ForeignKey(
                        name: "FK_Manager_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    stockNumber = table.Column<int>(type: "int", nullable: false),
                    goodsName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    storage = table.Column<int>(type: "int", nullable: false),
                    SupplyingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_StockItems_Supplying_SupplyingId",
                        column: x => x.SupplyingId,
                        principalTable: "Supplying",
                        principalColumn: "SupplyingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyingInvoice",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    invoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    goodsName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    supplierName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    discount = table.Column<double>(type: "double", nullable: false),
                    goodsAmount = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "double", nullable: false),
                    APDTotalCost = table.Column<double>(type: "double", nullable: false),
                    TotalOfPurchase = table.Column<double>(type: "double", nullable: false),
                    InvoiceStatus = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SupplyingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyingInvoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_SupplyingInvoice_Supplying_SupplyingId",
                        column: x => x.SupplyingId,
                        principalTable: "Supplying",
                        principalColumn: "SupplyingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    supplierName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    supplierPhone = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    supplierNumber = table.Column<int>(type: "int", nullable: false),
                    supplierLocation = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Supplier_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullReport",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    supplyingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    goodsName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    supplierName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    storage = table.Column<int>(type: "int", nullable: false),
                    EachSupplierTotal = table.Column<double>(type: "double", nullable: false),
                    TotalOfPurchase = table.Column<double>(type: "double", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    SupplyingInvoiceInvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullReport", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_FullReport_Manager_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manager",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FullReport_SupplyingInvoice_SupplyingInvoiceInvoiceId",
                        column: x => x.SupplyingInvoiceInvoiceId,
                        principalTable: "SupplyingInvoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplyingProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    SupplyingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyingProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplyingProcess_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyingProcess_Supplying_SupplyingId",
                        column: x => x.SupplyingId,
                        principalTable: "Supplying",
                        principalColumn: "SupplyingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FullReport_ManagerId",
                table: "FullReport",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_FullReport_SupplyingInvoiceInvoiceId",
                table: "FullReport",
                column: "SupplyingInvoiceInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_AddressId",
                table: "Manager",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItems_SupplyingId",
                table: "StockItems",
                column: "SupplyingId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ManagerId",
                table: "Supplier",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyingInvoice_SupplyingId",
                table: "SupplyingInvoice",
                column: "SupplyingId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyingProcess_SupplierId",
                table: "SupplyingProcess",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyingProcess_SupplyingId",
                table: "SupplyingProcess",
                column: "SupplyingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FullReport");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "SupplyingProcess");

            migrationBuilder.DropTable(
                name: "SupplyingInvoice");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Supplying");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
