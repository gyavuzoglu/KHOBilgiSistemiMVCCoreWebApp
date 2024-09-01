using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class createDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_AskeriSiniflarTbl_SinifID",
                table: "PersonelTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_BirimlerTbl_BirimID",
                table: "PersonelTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_GorevlerTbl_GorevID",
                table: "PersonelTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_RutbeTbl_RutbeID",
                table: "PersonelTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_UnvanTbl_UnvanID",
                table: "PersonelTbl");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "RolesTbl",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnvanID",
                table: "PersonelTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SinifID",
                table: "PersonelTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RutbeID",
                table: "PersonelTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "MisafirPersonel",
                table: "PersonelTbl",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "PersonelTbl",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "GorevID",
                table: "PersonelTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DahiliTelefonu",
                table: "PersonelTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BolumID",
                table: "PersonelTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BirimID",
                table: "PersonelTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_AskeriSiniflarTbl_SinifID",
                table: "PersonelTbl",
                column: "SinifID",
                principalTable: "AskeriSiniflarTbl",
                principalColumn: "SinifID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_BirimlerTbl_BirimID",
                table: "PersonelTbl",
                column: "BirimID",
                principalTable: "BirimlerTbl",
                principalColumn: "BirimID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_GorevlerTbl_GorevID",
                table: "PersonelTbl",
                column: "GorevID",
                principalTable: "GorevlerTbl",
                principalColumn: "GorevID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_RutbeTbl_RutbeID",
                table: "PersonelTbl",
                column: "RutbeID",
                principalTable: "RutbeTbl",
                principalColumn: "RutbeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_UnvanTbl_UnvanID",
                table: "PersonelTbl",
                column: "UnvanID",
                principalTable: "UnvanTbl",
                principalColumn: "UnvanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_AskeriSiniflarTbl_SinifID",
                table: "PersonelTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_BirimlerTbl_BirimID",
                table: "PersonelTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_GorevlerTbl_GorevID",
                table: "PersonelTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_RutbeTbl_RutbeID",
                table: "PersonelTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonelTbl_UnvanTbl_UnvanID",
                table: "PersonelTbl");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "RolesTbl",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnvanID",
                table: "PersonelTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SinifID",
                table: "PersonelTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RutbeID",
                table: "PersonelTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "KayitTarihi",
                table: "PersonelTbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GorevID",
                table: "PersonelTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DahiliTelefonu",
                table: "PersonelTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BolumID",
                table: "PersonelTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BirimID",
                table: "PersonelTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_AskeriSiniflarTbl_SinifID",
                table: "PersonelTbl",
                column: "SinifID",
                principalTable: "AskeriSiniflarTbl",
                principalColumn: "SinifID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_BirimlerTbl_BirimID",
                table: "PersonelTbl",
                column: "BirimID",
                principalTable: "BirimlerTbl",
                principalColumn: "BirimID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_GorevlerTbl_GorevID",
                table: "PersonelTbl",
                column: "GorevID",
                principalTable: "GorevlerTbl",
                principalColumn: "GorevID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_RutbeTbl_RutbeID",
                table: "PersonelTbl",
                column: "RutbeID",
                principalTable: "RutbeTbl",
                principalColumn: "RutbeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonelTbl_UnvanTbl_UnvanID",
                table: "PersonelTbl",
                column: "UnvanID",
                principalTable: "UnvanTbl",
                principalColumn: "UnvanID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
