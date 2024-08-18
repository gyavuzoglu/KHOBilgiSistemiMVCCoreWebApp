using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AskeriSiniflars",
                columns: table => new
                {
                    SinifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifUzun = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SinifKisa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AskeriSiniflars", x => x.SinifID);
                });

            migrationBuilder.CreateTable(
                name: "Birimlers",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birimlers", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "Derslers",
                columns: table => new
                {
                    DersKodu = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EOYiliID = table.Column<int>(type: "int", nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false),
                    DersAdi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    HaftalikDS = table.Column<int>(type: "int", nullable: false),
                    Kredi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AKTS = table.Column<int>(type: "int", nullable: false),
                    YaratilmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derslers", x => x.DersKodu);
                });

            migrationBuilder.CreateTable(
                name: "EOYilis",
                columns: table => new
                {
                    EOYiliID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EOYili = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EOYilis", x => x.EOYiliID);
                });

            migrationBuilder.CreateTable(
                name: "Gorevlers",
                columns: table => new
                {
                    GorevID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevlers", x => x.GorevID);
                });

            migrationBuilder.CreateTable(
                name: "Kisimlars",
                columns: table => new
                {
                    KisimID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisimAdi = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Sinif = table.Column<int>(type: "int", nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisimlars", x => x.KisimID);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciBilgileris",
                columns: table => new
                {
                    OgrenciTC = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KayitTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    OkulaGirisTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    AnneAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BabaAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DogumYeri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    AnneBabaMedeniDurum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AnneEgitim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BabaEgitim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnneGelir = table.Column<int>(type: "int", nullable: false),
                    BabaGelir = table.Column<int>(type: "int", nullable: false),
                    OgrenciGelir = table.Column<int>(type: "int", nullable: false),
                    KardesSayisi = table.Column<int>(type: "int", nullable: false),
                    LiseDiplomaNotu = table.Column<float>(type: "real", nullable: false),
                    MSUPuani = table.Column<float>(type: "real", nullable: false),
                    OSYMPuani = table.Column<float>(type: "real", nullable: false),
                    DisiplinPuani = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciBilgileris", x => x.OgrenciTC);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencilers",
                columns: table => new
                {
                    OgrenciTC = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YakaNo = table.Column<int>(type: "int", nullable: false),
                    Tabur = table.Column<int>(type: "int", nullable: false),
                    Boluk = table.Column<int>(type: "int", nullable: false),
                    KisimAdi = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Sinif = table.Column<int>(type: "int", nullable: false),
                    AskeriSinifID = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false),
                    UyrukID = table.Column<int>(type: "int", nullable: false),
                    Cinsiyeti = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Ayrildi = table.Column<bool>(type: "bit", nullable: false),
                    AyrilmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    Mezun = table.Column<bool>(type: "bit", nullable: false),
                    MezuniyetTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FotografAdresi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencilers", x => x.OgrenciTC);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelTC = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SinifID = table.Column<int>(type: "int", nullable: false),
                    RutbeID = table.Column<int>(type: "int", nullable: false),
                    UnvanID = table.Column<int>(type: "int", nullable: false),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false),
                    BirimID = table.Column<int>(type: "int", nullable: false),
                    MisafirPersonel = table.Column<bool>(type: "bit", nullable: false),
                    MisafirGorevYeri = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MisafirEvAdresi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OkulEPosta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DigerEPosta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CepTelefonu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DahiliTelefonu = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelTC);
                });

            migrationBuilder.CreateTable(
                name: "Profils",
                columns: table => new
                {
                    ProfilID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profils", x => x.ProfilID);
                });

            migrationBuilder.CreateTable(
                name: "Rutbes",
                columns: table => new
                {
                    RutbeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutbeUzun = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RutbeKisa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutbes", x => x.RutbeID);
                });

            migrationBuilder.CreateTable(
                name: "Unvans",
                columns: table => new
                {
                    UnvanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnvanUzun = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UnvanKisa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvans", x => x.UnvanID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserTC = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProfilID = table.Column<int>(type: "int", nullable: false),
                    SifreGuncellemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    YaratilmaTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    Pasif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserTC);
                });

            migrationBuilder.CreateTable(
                name: "Uyruks",
                columns: table => new
                {
                    UyrukID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uyruk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyruks", x => x.UyrukID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AskeriSiniflars");

            migrationBuilder.DropTable(
                name: "Birimlers");

            migrationBuilder.DropTable(
                name: "Derslers");

            migrationBuilder.DropTable(
                name: "EOYilis");

            migrationBuilder.DropTable(
                name: "Gorevlers");

            migrationBuilder.DropTable(
                name: "Kisimlars");

            migrationBuilder.DropTable(
                name: "OgrenciBilgileris");

            migrationBuilder.DropTable(
                name: "Ogrencilers");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Profils");

            migrationBuilder.DropTable(
                name: "Rutbes");

            migrationBuilder.DropTable(
                name: "Unvans");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "Uyruks");
        }
    }
}
