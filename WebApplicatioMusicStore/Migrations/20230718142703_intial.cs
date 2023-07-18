using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicatioMusicStore.Migrations
{
    public partial class intial : Migration
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
                    { 1, "0000", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7106) },
                    { 2, "1001", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7118) },
                    { 3, "1002", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7119) },
                    { 4, "1003", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7120) },
                    { 5, "1004", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7121) },
                    { 6, "1005", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7122) },
                    { 7, "1006", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7123) },
                    { 8, "1007", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7124) },
                    { 9, "1008", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7125) },
                    { 10, "1009", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7126) },
                    { 11, "1010", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7127) },
                    { 12, "1011", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7128) },
                    { 13, "1012", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7129) },
                    { 14, "1013", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7130) },
                    { 15, "1014", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7131) },
                    { 16, "1016", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7132) },
                    { 17, "1018", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7133) },
                    { 18, "1019", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7134) },
                    { 19, "1020", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7135) },
                    { 20, "1021", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7136) },
                    { 21, "1022", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7136) },
                    { 22, "1023", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7138) },
                    { 23, "1024", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7138) },
                    { 24, "1026", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7139) },
                    { 25, "1027", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7140) },
                    { 26, "1028", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7141) },
                    { 27, "1029", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7142) },
                    { 28, "1030", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7143) },
                    { 29, "1031", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7144) },
                    { 30, "1032", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7145) },
                    { 31, "1033", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7146) },
                    { 32, "1034", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7147) },
                    { 33, "1035", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7148) },
                    { 34, "1036", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7149) },
                    { 35, "1037", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7150) },
                    { 36, "1038", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7151) },
                    { 37, "1041", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7152) },
                    { 38, "1042", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7153) },
                    { 39, "1043", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7154) },
                    { 40, "1045", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7155) },
                    { 41, "1046", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7156) },
                    { 42, "1047", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7157) }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Code", "CreationDateTime" },
                values: new object[,]
                {
                    { 43, "1048", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7158) },
                    { 44, "1050", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7158) },
                    { 45, "1051", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7159) },
                    { 46, "1052", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7160) },
                    { 47, "1053", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7161) },
                    { 48, "1054", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7162) },
                    { 49, "1055", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7163) },
                    { 50, "1056", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7164) },
                    { 51, "1057", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7165) },
                    { 52, "1058", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7166) },
                    { 53, "1059", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7167) },
                    { 54, "1060", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7168) },
                    { 55, "1061", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7169) },
                    { 56, "1062", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7171) },
                    { 57, "1063", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7172) },
                    { 58, "1064", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7172) },
                    { 59, "1065", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7173) },
                    { 60, "1066", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7174) },
                    { 61, "1067", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7175) },
                    { 62, "1068", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7176) },
                    { 63, "1072", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7177) },
                    { 64, "1073", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7179) },
                    { 65, "1075", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7221) },
                    { 66, "1078", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7223) },
                    { 67, "1081", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7224) },
                    { 68, "8015", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7225) },
                    { 69, "9039", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7226) },
                    { 70, "9040", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7227) },
                    { 71, "9044", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7228) }
                });

            migrationBuilder.InsertData(
                table: "Registers",
                columns: new[] { "Id", "CreationDateTime", "StoreId" },
                values: new object[] { 1, new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7658), 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 1, "egomez", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7609), "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 2, "ag01", new DateTime(2023, 7, 18, 10, 27, 3, 24, DateTimeKind.Local).AddTicks(7638), "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87", "Store", 2 });

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
