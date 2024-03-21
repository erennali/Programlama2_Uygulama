using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Programlama2_UygulamaProjesi.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Konular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KonuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoruAndCevap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoruId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cevap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sira = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoruAndCevap", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sorular",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoruKoku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KonuId = table.Column<int>(type: "int", nullable: false),
                    ZorlukDerecesi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorular", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konular");

            migrationBuilder.DropTable(
                name: "SoruAndCevap");

            migrationBuilder.DropTable(
                name: "Sorular");
        }
    }
}
