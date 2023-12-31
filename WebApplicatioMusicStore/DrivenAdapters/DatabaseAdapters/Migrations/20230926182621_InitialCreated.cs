﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Activity = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registers_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Code", "CreationDateTime" },
                values: new object[,]
                {
                    { 1, "0000", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7083) },
                    { 2, "1001", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7104) },
                    { 3, "1002", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7105) },
                    { 4, "1003", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7106) },
                    { 5, "1004", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7107) },
                    { 6, "1005", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7109) },
                    { 7, "1006", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7110) },
                    { 8, "1007", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7111) },
                    { 9, "1008", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7112) },
                    { 10, "1009", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7113) },
                    { 11, "1010", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7114) },
                    { 12, "1011", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7115) },
                    { 13, "1012", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7117) },
                    { 14, "1013", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7118) },
                    { 15, "1014", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7119) },
                    { 16, "1016", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7120) },
                    { 17, "1018", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7121) },
                    { 18, "1019", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7122) },
                    { 19, "1020", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7123) },
                    { 20, "1021", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7124) },
                    { 21, "1022", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7126) },
                    { 22, "1023", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7127) },
                    { 23, "1024", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7128) },
                    { 24, "1026", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7129) },
                    { 25, "1027", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7130) },
                    { 26, "1028", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7131) },
                    { 27, "1029", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7132) },
                    { 28, "1030", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7134) },
                    { 29, "1031", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7135) },
                    { 30, "1032", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7136) },
                    { 31, "1033", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7137) },
                    { 32, "1034", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7138) },
                    { 33, "1035", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7139) },
                    { 34, "1036", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7140) },
                    { 35, "1037", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7142) },
                    { 36, "1038", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7143) },
                    { 37, "1041", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7144) },
                    { 38, "1042", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7145) },
                    { 39, "1043", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7146) },
                    { 40, "1045", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7147) },
                    { 41, "1046", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7148) },
                    { 42, "1047", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7149) }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Code", "CreationDateTime" },
                values: new object[,]
                {
                    { 43, "1048", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7151) },
                    { 44, "1050", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7152) },
                    { 45, "1051", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7153) },
                    { 46, "1052", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7154) },
                    { 47, "1053", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7155) },
                    { 48, "1054", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7156) },
                    { 49, "1055", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7157) },
                    { 50, "1056", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7158) },
                    { 51, "1057", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7159) },
                    { 52, "1058", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7161) },
                    { 53, "1059", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7162) },
                    { 54, "1060", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7163) },
                    { 55, "1061", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7164) },
                    { 56, "1062", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7165) },
                    { 57, "1063", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7166) },
                    { 58, "1064", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7167) },
                    { 59, "1065", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7168) },
                    { 60, "1066", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7169) },
                    { 61, "1067", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7171) },
                    { 62, "1068", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7172) },
                    { 63, "1072", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7173) },
                    { 64, "1073", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7174) },
                    { 65, "1075", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7175) },
                    { 66, "1078", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7176) },
                    { 67, "1081", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7177) },
                    { 68, "8015", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7178) },
                    { 69, "9039", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7180) },
                    { 70, "9040", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7181) },
                    { 71, "9044", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7184) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 1, "egomez", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7598), "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 2, "rnajm", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7630), "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 3, "ag01", new DateTime(2023, 9, 26, 14, 26, 21, 120, DateTimeKind.Local).AddTicks(7660), "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "Store", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_StoreId",
                table: "Registers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StoreId",
                table: "Users",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
