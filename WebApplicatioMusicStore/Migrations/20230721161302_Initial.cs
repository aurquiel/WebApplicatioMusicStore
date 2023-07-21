using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicatioMusicStore.Migrations
{
    public partial class Initial : Migration
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
                    Operation = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
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
                    { 1, "0000", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4852) },
                    { 2, "1001", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4933) },
                    { 3, "1002", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4934) },
                    { 4, "1003", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4935) },
                    { 5, "1004", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4936) },
                    { 6, "1005", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4937) },
                    { 7, "1006", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4939) },
                    { 8, "1007", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4940) },
                    { 9, "1008", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4941) },
                    { 10, "1009", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4942) },
                    { 11, "1010", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4943) },
                    { 12, "1011", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4945) },
                    { 13, "1012", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4946) },
                    { 14, "1013", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4947) },
                    { 15, "1014", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4948) },
                    { 16, "1016", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4950) },
                    { 17, "1018", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4951) },
                    { 18, "1019", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4952) },
                    { 19, "1020", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4953) },
                    { 20, "1021", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4954) },
                    { 21, "1022", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4955) },
                    { 22, "1023", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4956) },
                    { 23, "1024", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4957) },
                    { 24, "1026", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4959) },
                    { 25, "1027", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4960) },
                    { 26, "1028", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4961) },
                    { 27, "1029", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4962) },
                    { 28, "1030", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4963) },
                    { 29, "1031", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4964) },
                    { 30, "1032", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4965) },
                    { 31, "1033", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4966) },
                    { 32, "1034", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4968) },
                    { 33, "1035", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4969) },
                    { 34, "1036", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4970) },
                    { 35, "1037", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4971) },
                    { 36, "1038", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4972) },
                    { 37, "1041", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4973) },
                    { 38, "1042", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4974) },
                    { 39, "1043", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4975) },
                    { 40, "1045", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4976) },
                    { 41, "1046", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4977) },
                    { 42, "1047", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4979) }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Code", "CreationDateTime" },
                values: new object[,]
                {
                    { 43, "1048", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4980) },
                    { 44, "1050", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4981) },
                    { 45, "1051", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4982) },
                    { 46, "1052", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4983) },
                    { 47, "1053", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4984) },
                    { 48, "1054", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4985) },
                    { 49, "1055", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4986) },
                    { 50, "1056", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4987) },
                    { 51, "1057", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4989) },
                    { 52, "1058", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4990) },
                    { 53, "1059", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4991) },
                    { 54, "1060", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4992) },
                    { 55, "1061", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(4993) },
                    { 56, "1062", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5039) },
                    { 57, "1063", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5041) },
                    { 58, "1064", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5042) },
                    { 59, "1065", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5043) },
                    { 60, "1066", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5044) },
                    { 61, "1067", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5045) },
                    { 62, "1068", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5046) },
                    { 63, "1072", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5047) },
                    { 64, "1073", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5048) },
                    { 65, "1075", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5049) },
                    { 66, "1078", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5050) },
                    { 67, "1081", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5051) },
                    { 68, "8015", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5052) },
                    { 69, "9039", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5054) },
                    { 70, "9040", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5055) },
                    { 71, "9044", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5056) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 1, "egomez", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5442), "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 2, "rnajm", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5472), "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 3, "ag01", new DateTime(2023, 7, 21, 12, 13, 2, 798, DateTimeKind.Local).AddTicks(5540), "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "Store", 2 });

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
