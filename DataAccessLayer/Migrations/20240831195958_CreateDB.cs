using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AskeriSiniflarTbl",
                columns: table => new
                {
                    SinifID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifUzun = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SinifKisa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AskeriSiniflarTbl", x => x.SinifID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BirimlerTbl",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirimlerTbl", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "BolumlerTbl",
                columns: table => new
                {
                    BolumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BolumAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolumlerTbl", x => x.BolumID);
                });

            migrationBuilder.CreateTable(
                name: "EOYiliTbl",
                columns: table => new
                {
                    EOYiliID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EOYili = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EOYiliTbl", x => x.EOYiliID);
                });

            migrationBuilder.CreateTable(
                name: "GorevlerTbl",
                columns: table => new
                {
                    GorevID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevAdi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GorevlerTbl", x => x.GorevID);
                });

            migrationBuilder.CreateTable(
                name: "RolesTbl",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesTbl", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "RutbeTbl",
                columns: table => new
                {
                    RutbeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutbeUzun = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RutbeKisa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RutbeTbl", x => x.RutbeID);
                });

            migrationBuilder.CreateTable(
                name: "UnvanTbl",
                columns: table => new
                {
                    UnvanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnvanUzun = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    UnvanKisa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnvanTbl", x => x.UnvanID);
                });

            migrationBuilder.CreateTable(
                name: "UserTbl",
                columns: table => new
                {
                    UserTC = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SifreGuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YaratilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Personelmi = table.Column<bool>(type: "bit", nullable: false),
                    Ogrencimi = table.Column<bool>(type: "bit", nullable: false),
                    AktifPasif = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTbl", x => x.UserTC);
                });

            migrationBuilder.CreateTable(
                name: "UyrukTbl",
                columns: table => new
                {
                    UyrukID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uyruk = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UyrukTbl", x => x.UyrukID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KisimlarTbl",
                columns: table => new
                {
                    KisimAdi = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Sinif = table.Column<int>(type: "int", nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisimlarTbl", x => x.KisimAdi);
                    table.ForeignKey(
                        name: "FK_KisimlarTbl_BolumlerTbl_BolumID",
                        column: x => x.BolumID,
                        principalTable: "BolumlerTbl",
                        principalColumn: "BolumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DerslerTbl",
                columns: table => new
                {
                    DersKodu = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    EOYiliID = table.Column<int>(type: "int", nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false),
                    DersAdi = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    HaftalikDS = table.Column<int>(type: "int", nullable: false),
                    Kredi = table.Column<float>(type: "real", nullable: false),
                    AKTS = table.Column<int>(type: "int", nullable: false),
                    YaratilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DerslerTbl", x => x.DersKodu);
                    table.ForeignKey(
                        name: "FK_DerslerTbl_BolumlerTbl_BolumID",
                        column: x => x.BolumID,
                        principalTable: "BolumlerTbl",
                        principalColumn: "BolumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DerslerTbl_EOYiliTbl_EOYiliID",
                        column: x => x.EOYiliID,
                        principalTable: "EOYiliTbl",
                        principalColumn: "EOYiliID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelTbl",
                columns: table => new
                {
                    PersonelTC = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SinifID = table.Column<int>(type: "int", nullable: false),
                    RutbeID = table.Column<int>(type: "int", nullable: false),
                    UnvanID = table.Column<int>(type: "int", nullable: false),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false),
                    BirimID = table.Column<int>(type: "int", nullable: false),
                    MisafirPersonel = table.Column<bool>(type: "bit", nullable: false),
                    MisafirGorevYeri = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MisafirEvAdresi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OkulEPosta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DigerEPosta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CepTelefonu = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DahiliTelefonu = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelTbl", x => x.PersonelTC);
                    table.ForeignKey(
                        name: "FK_PersonelTbl_AskeriSiniflarTbl_SinifID",
                        column: x => x.SinifID,
                        principalTable: "AskeriSiniflarTbl",
                        principalColumn: "SinifID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelTbl_BirimlerTbl_BirimID",
                        column: x => x.BirimID,
                        principalTable: "BirimlerTbl",
                        principalColumn: "BirimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelTbl_GorevlerTbl_GorevID",
                        column: x => x.GorevID,
                        principalTable: "GorevlerTbl",
                        principalColumn: "GorevID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelTbl_RutbeTbl_RutbeID",
                        column: x => x.RutbeID,
                        principalTable: "RutbeTbl",
                        principalColumn: "RutbeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonelTbl_UnvanTbl_UnvanID",
                        column: x => x.UnvanID,
                        principalTable: "UnvanTbl",
                        principalColumn: "UnvanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciHareketleriTbl",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTC = table.Column<long>(type: "bigint", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciHareketleriTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciHareketleriTbl_UserTbl_UserTC",
                        column: x => x.UserTC,
                        principalTable: "UserTbl",
                        principalColumn: "UserTC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRolesTbl",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTC = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRolesTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRolesTbl_RolesTbl_RoleID",
                        column: x => x.RoleID,
                        principalTable: "RolesTbl",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRolesTbl_UserTbl_UserTC",
                        column: x => x.UserTC,
                        principalTable: "UserTbl",
                        principalColumn: "UserTC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrencilerTbl",
                columns: table => new
                {
                    OgrenciTC = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YakaNo = table.Column<int>(type: "int", nullable: false),
                    Tabur = table.Column<int>(type: "int", nullable: false),
                    Boluk = table.Column<int>(type: "int", nullable: false),
                    KisimAdi = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Sinif = table.Column<int>(type: "int", nullable: false),
                    AskeriSinifID = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BolumID = table.Column<int>(type: "int", nullable: false),
                    UyrukID = table.Column<int>(type: "int", nullable: false),
                    Cinsiyeti = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Ayrildi = table.Column<bool>(type: "bit", nullable: false),
                    AyrilmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mezun = table.Column<bool>(type: "bit", nullable: false),
                    MezuniyetTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EPosta = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    FotografAdresi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrencilerTbl", x => x.OgrenciTC);
                    table.ForeignKey(
                        name: "FK_OgrencilerTbl_BolumlerTbl_BolumID",
                        column: x => x.BolumID,
                        principalTable: "BolumlerTbl",
                        principalColumn: "BolumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrencilerTbl_KisimlarTbl_KisimAdi",
                        column: x => x.KisimAdi,
                        principalTable: "KisimlarTbl",
                        principalColumn: "KisimAdi");
                    table.ForeignKey(
                        name: "FK_OgrencilerTbl_UyrukTbl_UyrukID",
                        column: x => x.UyrukID,
                        principalTable: "UyrukTbl",
                        principalColumn: "UyrukID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciBilgileriTbl",
                columns: table => new
                {
                    OgrenciTC = table.Column<long>(type: "bigint", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OkulaGirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnneAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BabaAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DogumYeri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnneBabaMedeniDurum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AnneEgitim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BabaEgitim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_OgrenciBilgileriTbl", x => x.OgrenciTC);
                    table.ForeignKey(
                        name: "FK_OgrenciBilgileriTbl_OgrencilerTbl_OgrenciTC",
                        column: x => x.OgrenciTC,
                        principalTable: "OgrencilerTbl",
                        principalColumn: "OgrenciTC",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DerslerTbl_BolumID",
                table: "DerslerTbl",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_DerslerTbl_EOYiliID",
                table: "DerslerTbl",
                column: "EOYiliID");

            migrationBuilder.CreateIndex(
                name: "IX_KisimlarTbl_BolumID",
                table: "KisimlarTbl",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciHareketleriTbl_UserTC",
                table: "KullaniciHareketleriTbl",
                column: "UserTC");

            migrationBuilder.CreateIndex(
                name: "IX_OgrencilerTbl_BolumID",
                table: "OgrencilerTbl",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_OgrencilerTbl_KisimAdi",
                table: "OgrencilerTbl",
                column: "KisimAdi");

            migrationBuilder.CreateIndex(
                name: "IX_OgrencilerTbl_UyrukID",
                table: "OgrencilerTbl",
                column: "UyrukID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelTbl_BirimID",
                table: "PersonelTbl",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelTbl_GorevID",
                table: "PersonelTbl",
                column: "GorevID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelTbl_RutbeID",
                table: "PersonelTbl",
                column: "RutbeID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelTbl_SinifID",
                table: "PersonelTbl",
                column: "SinifID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelTbl_UnvanID",
                table: "PersonelTbl",
                column: "UnvanID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesTbl_RoleID",
                table: "UserRolesTbl",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRolesTbl_UserTC",
                table: "UserRolesTbl",
                column: "UserTC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DerslerTbl");

            migrationBuilder.DropTable(
                name: "KullaniciHareketleriTbl");

            migrationBuilder.DropTable(
                name: "OgrenciBilgileriTbl");

            migrationBuilder.DropTable(
                name: "PersonelTbl");

            migrationBuilder.DropTable(
                name: "UserRolesTbl");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EOYiliTbl");

            migrationBuilder.DropTable(
                name: "OgrencilerTbl");

            migrationBuilder.DropTable(
                name: "AskeriSiniflarTbl");

            migrationBuilder.DropTable(
                name: "BirimlerTbl");

            migrationBuilder.DropTable(
                name: "GorevlerTbl");

            migrationBuilder.DropTable(
                name: "RutbeTbl");

            migrationBuilder.DropTable(
                name: "UnvanTbl");

            migrationBuilder.DropTable(
                name: "RolesTbl");

            migrationBuilder.DropTable(
                name: "UserTbl");

            migrationBuilder.DropTable(
                name: "KisimlarTbl");

            migrationBuilder.DropTable(
                name: "UyrukTbl");

            migrationBuilder.DropTable(
                name: "BolumlerTbl");
        }
    }
}
