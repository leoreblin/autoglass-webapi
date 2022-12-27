using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoglass.Backend.Data.SQL.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fornecedor",
                columns: new[] { "Id", "Cnpj", "Descricao" },
                values: new object[] { 1L, "12123123000122", "Fornecedor de para-brisa" });

            migrationBuilder.InsertData(
                table: "Fornecedor",
                columns: new[] { "Id", "Cnpj", "Descricao" },
                values: new object[] { 2L, "34345345000144", "Fornecedor de retrovisor" });

            migrationBuilder.InsertData(
                table: "Fornecedor",
                columns: new[] { "Id", "Cnpj", "Descricao" },
                values: new object[] { 3L, "12456456000166", "Fornecedor de vidro" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fornecedor",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Fornecedor",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Fornecedor",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
