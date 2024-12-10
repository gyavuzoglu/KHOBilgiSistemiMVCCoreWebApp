using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KisimlarTbl_BolumlerTbl_BolumID",
                table: "KisimlarTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciBilgileriTbl_OgrencilerTbl_OgrenciTC",
                table: "OgrenciBilgileriTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelTbl",
                table: "PersonelTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OgrencilerTbl",
                table: "OgrencilerTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OgrenciBilgileriTbl",
                table: "OgrenciBilgileriTbl");

            migrationBuilder.AlterColumn<string>(
                name: "Soyadi",
                table: "PersonelTbl",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "MisafirPersonel",
                table: "PersonelTbl",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "PersonelTbl",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonelTC",
                table: "PersonelTbl",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PerId",
                table: "PersonelTbl",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "OgrenciTC",
                table: "OgrencilerTbl",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "OgrenciID",
                table: "OgrencilerTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "OgrenciTC",
                table: "OgrenciBilgileriTbl",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "OgrBilgiID",
                table: "OgrenciBilgileriTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "OgrenciID",
                table: "OgrenciBilgileriTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "Sinif",
                table: "KisimlarTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BolumID",
                table: "KisimlarTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelTbl",
                table: "PersonelTbl",
                column: "PerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OgrencilerTbl",
                table: "OgrencilerTbl",
                column: "OgrenciID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OgrenciBilgileriTbl",
                table: "OgrenciBilgileriTbl",
                column: "OgrBilgiID");

            migrationBuilder.CreateTable(
                name: "AkademikDanismanlarTbl",
                columns: table => new
                {
                    DanismanlikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerID = table.Column<int>(type: "int", nullable: false),
                    GorevID = table.Column<int>(type: "int", nullable: false),
                    Sinif = table.Column<int>(type: "int", nullable: false),
                    EOYiliID = table.Column<int>(type: "int", nullable: false),
                    KisimAdi = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkademikDanismanlarTbl", x => x.DanismanlikID);
                });

            migrationBuilder.CreateTable(
                name: "KisimDegerlendirmeleriTbl",
                columns: table => new
                {
                    KisimDegerlendirmeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisimAdi = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    PerID = table.Column<int>(type: "int", nullable: false),
                    TarihSaat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KisimDegerlendirme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EOYiliID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisimDegerlendirmeleriTbl", x => x.KisimDegerlendirmeID);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciDegerlendirmeTurleriTbl",
                columns: table => new
                {
                    DegTurID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDegerlendirmeTurleriTbl", x => x.DegTurID);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciDegerlendirmeleriTbl",
                columns: table => new
                {
                    DegerlendirmeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegTurID = table.Column<int>(type: "int", nullable: false),
                    OgrenciID = table.Column<long>(type: "bigint", nullable: false),
                    PerID = table.Column<int>(type: "int", nullable: false),
                    TarihSaat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Degerlendirme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EOYiliID = table.Column<int>(type: "int", nullable: false),
                    Donem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDegerlendirmeleriTbl", x => x.DegerlendirmeID);
                    table.ForeignKey(
                        name: "FK_OgrenciDegerlendirmeleriTbl_EOYiliTbl_EOYiliID",
                        column: x => x.EOYiliID,
                        principalTable: "EOYiliTbl",
                        principalColumn: "EOYiliID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDegerlendirmeleriTbl_OgrenciDegerlendirmeTurleriTbl_DegTurID",
                        column: x => x.DegTurID,
                        principalTable: "OgrenciDegerlendirmeTurleriTbl",
                        principalColumn: "DegTurID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDegerlendirmeleriTbl_OgrencilerTbl_OgrenciID",
                        column: x => x.OgrenciID,
                        principalTable: "OgrencilerTbl",
                        principalColumn: "OgrenciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDegerlendirmeleriTbl_PersonelTbl_PerID",
                        column: x => x.PerID,
                        principalTable: "PersonelTbl",
                        principalColumn: "PerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonelTbl_BolumID",
                table: "PersonelTbl",
                column: "BolumID");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciBilgileriTbl_OgrenciID",
                table: "OgrenciBilgileriTbl",
                column: "OgrenciID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDegerlendirmeleriTbl_DegTurID",
                table: "OgrenciDegerlendirmeleriTbl",
                column: "DegTurID");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDegerlendirmeleriTbl_EOYiliID",
                table: "OgrenciDegerlendirmeleriTbl",
                column: "EOYiliID");

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDegerlendirmeleriTbl_OgrenciID",
                table: "OgrenciDegerlendirmeleriTbl",
                column: "OgrenciID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDegerlendirmeleriTbl_PerID",
                table: "OgrenciDegerlendirmeleriTbl",
                column: "PerID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KisimlarTbl_BolumlerTbl_BolumID",
                table: "KisimlarTbl",
                column: "BolumID",
                principalTable: "BolumlerTbl",
                principalColumn: "BolumID");

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciBilgileriTbl_OgrencilerTbl_OgrenciID",
                table: "OgrenciBilgileriTbl",
                column: "OgrenciID",
                principalTable: "OgrencilerTbl",
                principalColumn: "OgrenciID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_BolumlerTbl_BolumID",
                table: "PersonelTbl",
                column: "BolumID",
                principalTable: "BolumlerTbl",
                principalColumn: "BolumID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KisimlarTbl_BolumlerTbl_BolumID",
                table: "KisimlarTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_OgrenciBilgileriTbl_OgrencilerTbl_OgrenciID",
                table: "OgrenciBilgileriTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_BolumlerTbl_BolumID",
                table: "PersonelTbl");

            migrationBuilder.DropTable(
                name: "AkademikDanismanlarTbl");

            migrationBuilder.DropTable(
                name: "KisimDegerlendirmeleriTbl");

            migrationBuilder.DropTable(
                name: "OgrenciDegerlendirmeleriTbl");

            migrationBuilder.DropTable(
                name: "OgrenciDegerlendirmeTurleriTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonelTbl",
                table: "PersonelTbl");

            migrationBuilder.DropIndex(
                name: "IX_PersonelTbl_BolumID",
                table: "PersonelTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OgrencilerTbl",
                table: "OgrencilerTbl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OgrenciBilgileriTbl",
                table: "OgrenciBilgileriTbl");

            migrationBuilder.DropIndex(
                name: "IX_OgrenciBilgileriTbl_OgrenciID",
                table: "OgrenciBilgileriTbl");

            migrationBuilder.DropColumn(
                name: "PerId",
                table: "PersonelTbl");

            migrationBuilder.DropColumn(
                name: "OgrenciID",
                table: "OgrencilerTbl");

            migrationBuilder.DropColumn(
                name: "OgrBilgiID",
                table: "OgrenciBilgileriTbl");

            migrationBuilder.DropColumn(
                name: "OgrenciID",
                table: "OgrenciBilgileriTbl");

            migrationBuilder.AlterColumn<string>(
                name: "Soyadi",
                table: "PersonelTbl",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<long>(
                name: "PersonelTC",
                table: "PersonelTbl",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<bool>(
                name: "MisafirPersonel",
                table: "PersonelTbl",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "PersonelTbl",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<long>(
                name: "OgrenciTC",
                table: "OgrencilerTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<long>(
                name: "OgrenciTC",
                table: "OgrenciBilgileriTbl",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Sinif",
                table: "KisimlarTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BolumID",
                table: "KisimlarTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonelTbl",
                table: "PersonelTbl",
                column: "PersonelTC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OgrencilerTbl",
                table: "OgrencilerTbl",
                column: "OgrenciTC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OgrenciBilgileriTbl",
                table: "OgrenciBilgileriTbl",
                column: "OgrenciTC");

            migrationBuilder.AddForeignKey(
                name: "FK_KisimlarTbl_BolumlerTbl_BolumID",
                table: "KisimlarTbl",
                column: "BolumID",
                principalTable: "BolumlerTbl",
                principalColumn: "BolumID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OgrenciBilgileriTbl_OgrencilerTbl_OgrenciTC",
                table: "OgrenciBilgileriTbl",
                column: "OgrenciTC",
                principalTable: "OgrencilerTbl",
                principalColumn: "OgrenciTC",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
