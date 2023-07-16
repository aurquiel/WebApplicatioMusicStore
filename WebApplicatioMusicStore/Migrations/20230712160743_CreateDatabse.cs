using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicatioMusicStore.Migrations
{
    public partial class CreateDatabse : Migration
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

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Code", "CreationDateTime" },
                values: new object[,]
                {
                    { 1, "0000", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6570) },
                    { 2, "1001", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6593) },
                    { 3, "1002", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6594) },
                    { 4, "1003", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6595) },
                    { 5, "1004", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6596) },
                    { 6, "1005", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6597) },
                    { 7, "1006", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6598) },
                    { 8, "1007", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6599) },
                    { 9, "1008", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6600) },
                    { 10, "1009", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6601) },
                    { 11, "1010", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6602) },
                    { 12, "1011", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6603) },
                    { 13, "1012", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6604) },
                    { 14, "1013", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6605) },
                    { 15, "1014", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6606) },
                    { 16, "1016", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6606) },
                    { 17, "1018", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6607) },
                    { 18, "1019", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6608) },
                    { 19, "1020", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6609) },
                    { 20, "1021", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6610) },
                    { 21, "1022", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6611) },
                    { 22, "1023", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6612) },
                    { 23, "1024", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6613) },
                    { 24, "1026", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6614) },
                    { 25, "1027", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6615) },
                    { 26, "1028", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6616) },
                    { 27, "1029", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6617) },
                    { 28, "1030", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6618) },
                    { 29, "1031", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6619) },
                    { 30, "1032", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6619) },
                    { 31, "1033", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6620) },
                    { 32, "1034", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6621) },
                    { 33, "1035", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6622) },
                    { 34, "1036", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6623) },
                    { 35, "1037", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6624) },
                    { 36, "1038", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6625) },
                    { 37, "1041", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6626) },
                    { 38, "1042", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6627) },
                    { 39, "1043", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6628) },
                    { 40, "1045", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6629) },
                    { 41, "1046", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6630) },
                    { 42, "1047", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6631) }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Code", "CreationDateTime" },
                values: new object[,]
                {
                    { 43, "1048", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6632) },
                    { 44, "1050", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6633) },
                    { 45, "1051", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6633) },
                    { 46, "1052", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6634) },
                    { 47, "1053", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6635) },
                    { 48, "1054", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6636) },
                    { 49, "1055", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6637) },
                    { 50, "1056", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6638) },
                    { 51, "1057", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6639) },
                    { 52, "1058", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6640) },
                    { 53, "1059", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6641) },
                    { 54, "1060", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6642) },
                    { 55, "1061", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6643) },
                    { 56, "1062", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6644) },
                    { 57, "1063", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6645) },
                    { 58, "1064", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6645) },
                    { 59, "1065", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6646) },
                    { 60, "1066", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6647) },
                    { 61, "1067", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6648) },
                    { 62, "1068", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6651) },
                    { 63, "1072", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6652) },
                    { 64, "1073", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6652) },
                    { 65, "1075", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6653) },
                    { 66, "1078", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6654) },
                    { 67, "1081", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6655) },
                    { 68, "8015", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6656) },
                    { 69, "9039", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6657) },
                    { 70, "9040", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6658) },
                    { 71, "9044", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6659) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 1, "egomez", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(7103), "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 2, "ag01", new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(7172), "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87", "Store", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_UserId",
                table: "Registers",
                column: "UserId");

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
