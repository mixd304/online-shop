using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace it_shop_app.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(nullable: true),
                    Beschreibung = table.Column<string>(nullable: true),
                    Preis = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Warenkoerbe",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warenkoerbe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Merkmale",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Bezeichnung = table.Column<string>(nullable: true),
                    Wert = table.Column<string>(nullable: true),
                    Artikel_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merkmale", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Merkmale_Artikel_Artikel_ID",
                        column: x => x.Artikel_ID,
                        principalTable: "Artikel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nutzer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Vorname = table.Column<string>(nullable: true),
                    Nachname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Plz = table.Column<string>(nullable: true),
                    Ort = table.Column<string>(nullable: true),
                    Straße = table.Column<string>(nullable: true),
                    Hausnummer = table.Column<int>(nullable: false),
                    Geburtsdatum = table.Column<DateTime>(nullable: false),
                    Warenkorb_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutzer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Nutzer_Warenkoerbe_Warenkorb_ID",
                        column: x => x.Warenkorb_ID,
                        principalTable: "Warenkoerbe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarenkorbArtikel",
                columns: table => new
                {
                    Artikel_ID = table.Column<int>(nullable: false),
                    Warenkorb_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarenkorbArtikel", x => new { x.Warenkorb_ID, x.Artikel_ID });
                    table.ForeignKey(
                        name: "FK_WarenkorbArtikel_Artikel_Artikel_ID",
                        column: x => x.Artikel_ID,
                        principalTable: "Artikel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WarenkorbArtikel_Warenkoerbe_Warenkorb_ID",
                        column: x => x.Warenkorb_ID,
                        principalTable: "Warenkoerbe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bestellungen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gesamtpreis = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Bestelldatum = table.Column<DateTime>(nullable: false),
                    Nutzer_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellungen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bestellungen_Nutzer_Nutzer_ID",
                        column: x => x.Nutzer_ID,
                        principalTable: "Nutzer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Listen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bezeichnung = table.Column<string>(nullable: true),
                    Nutzer_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Listen_Nutzer_Nutzer_ID",
                        column: x => x.Nutzer_ID,
                        principalTable: "Nutzer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtikelBestellungen",
                columns: table => new
                {
                    Artikel_ID = table.Column<int>(nullable: false),
                    Bestellung_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtikelBestellungen", x => new { x.Artikel_ID, x.Bestellung_ID });
                    table.ForeignKey(
                        name: "FK_ArtikelBestellungen_Artikel_Artikel_ID",
                        column: x => x.Artikel_ID,
                        principalTable: "Artikel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtikelBestellungen_Bestellungen_Bestellung_ID",
                        column: x => x.Bestellung_ID,
                        principalTable: "Bestellungen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListenArtikel",
                columns: table => new
                {
                    Artikel_ID = table.Column<int>(nullable: false),
                    Liste_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListenArtikel", x => new { x.Liste_ID, x.Artikel_ID });
                    table.ForeignKey(
                        name: "FK_ListenArtikel_Artikel_Artikel_ID",
                        column: x => x.Artikel_ID,
                        principalTable: "Artikel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListenArtikel_Listen_Liste_ID",
                        column: x => x.Liste_ID,
                        principalTable: "Listen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtikelBestellungen_Bestellung_ID",
                table: "ArtikelBestellungen",
                column: "Bestellung_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellungen_Nutzer_ID",
                table: "Bestellungen",
                column: "Nutzer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Listen_Nutzer_ID",
                table: "Listen",
                column: "Nutzer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ListenArtikel_Artikel_ID",
                table: "ListenArtikel",
                column: "Artikel_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Merkmale_Artikel_ID",
                table: "Merkmale",
                column: "Artikel_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Nutzer_Warenkorb_ID",
                table: "Nutzer",
                column: "Warenkorb_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarenkorbArtikel_Artikel_ID",
                table: "WarenkorbArtikel",
                column: "Artikel_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtikelBestellungen");

            migrationBuilder.DropTable(
                name: "ListenArtikel");

            migrationBuilder.DropTable(
                name: "Merkmale");

            migrationBuilder.DropTable(
                name: "WarenkorbArtikel");

            migrationBuilder.DropTable(
                name: "Bestellungen");

            migrationBuilder.DropTable(
                name: "Listen");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Nutzer");

            migrationBuilder.DropTable(
                name: "Warenkoerbe");
        }
    }
}
