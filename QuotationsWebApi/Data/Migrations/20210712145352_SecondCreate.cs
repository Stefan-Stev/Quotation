using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotationsWebApi.Data.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    DossierId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DossierName = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.DossierId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_DossierId",
                table: "Quotations",
                column: "DossierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Dossiers_DossierId",
                table: "Quotations",
                column: "DossierId",
                principalTable: "Dossiers",
                principalColumn: "DossierId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Dossiers_DossierId",
                table: "Quotations");

            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_DossierId",
                table: "Quotations");
        }
    }
}
