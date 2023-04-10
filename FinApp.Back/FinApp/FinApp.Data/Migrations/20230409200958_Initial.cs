using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinancialRelease",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    CNPJ = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ZipCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialRelease", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialRelease_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Operation",
                columns: new[] { "Id", "Description", "Status" },
                values: new object[] { 1, "EMPRESA XYP", "Enviando" });

            migrationBuilder.InsertData(
                table: "FinancialRelease",
                columns: new[] { "Id", "Address", "Amount", "CNPJ", "City", "Discount", "District", "DueDate", "Name", "Number", "OperationId", "Phone", "ReleaseDate", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Rua dos Canários, 123", 40000m, "15098917000148", "Curitiba", 20000m, "Centro", new DateTime(2023, 5, 9, 17, 9, 58, 361, DateTimeKind.Local).AddTicks(8790), "EMPRESA XYP", "ID 9932931", 1, "47 9998-74566", new DateTime(2023, 4, 9, 17, 9, 58, 361, DateTimeKind.Local).AddTicks(8776), "PR", "89295-024" },
                    { 2, "Rua dos Canários, 123", 40000m, "15098917000148", "Curitiba", 20000m, "Centro", new DateTime(2023, 6, 8, 17, 9, 58, 361, DateTimeKind.Local).AddTicks(8820), "EMPRESA XYP", "ID 9932931", 1, "47 9998-74566", new DateTime(2023, 5, 9, 17, 9, 58, 361, DateTimeKind.Local).AddTicks(8818), "PR", "89295-024" },
                    { 3, "Rua dos Canários, 123", 40000m, "15098917000148", "Curitiba", 20000m, "Centro", new DateTime(2023, 7, 8, 17, 9, 58, 361, DateTimeKind.Local).AddTicks(8833), "EMPRESA XYP", "ID 9932931", 1, "47 9998-74566", new DateTime(2023, 6, 8, 17, 9, 58, 361, DateTimeKind.Local).AddTicks(8832), "PR", "89295-024" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FinancialRelease_OperationId",
                table: "FinancialRelease",
                column: "OperationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinancialRelease");

            migrationBuilder.DropTable(
                name: "Operation");
        }
    }
}
