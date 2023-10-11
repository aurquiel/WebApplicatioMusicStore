using System;
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
                name: "AudioList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckForTime = table.Column<bool>(type: "bit", nullable: false),
                    TimeToPlay = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioList_Stores_StoreId",
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
                    { 1, "0000", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3570) },
                    { 2, "1001", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3587) },
                    { 3, "1002", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3588) },
                    { 4, "1003", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3589) },
                    { 5, "1004", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3590) },
                    { 6, "1005", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3591) },
                    { 7, "1006", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3592) },
                    { 8, "1007", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3593) },
                    { 9, "1008", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3594) },
                    { 10, "1009", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3595) },
                    { 11, "1010", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3596) },
                    { 12, "1011", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3597) },
                    { 13, "1012", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3598) },
                    { 14, "1013", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3599) },
                    { 15, "1014", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3600) },
                    { 16, "1016", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3601) },
                    { 17, "1018", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3602) },
                    { 18, "1019", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3603) },
                    { 19, "1020", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3604) },
                    { 20, "1021", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3605) },
                    { 21, "1022", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3606) },
                    { 22, "1023", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3607) },
                    { 23, "1024", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3608) },
                    { 24, "1026", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3608) },
                    { 25, "1027", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3609) },
                    { 26, "1028", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3610) },
                    { 27, "1029", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3611) },
                    { 28, "1030", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3612) },
                    { 29, "1031", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3613) },
                    { 30, "1032", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3614) },
                    { 31, "1033", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3615) },
                    { 32, "1034", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3616) },
                    { 33, "1035", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3617) },
                    { 34, "1036", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3701) },
                    { 35, "1037", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3703) },
                    { 36, "1038", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3704) },
                    { 37, "1041", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3705) },
                    { 38, "1042", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3706) },
                    { 39, "1043", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3707) },
                    { 40, "1045", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3708) },
                    { 41, "1046", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3708) },
                    { 42, "1047", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3709) }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Code", "CreationDateTime" },
                values: new object[,]
                {
                    { 43, "1048", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3710) },
                    { 44, "1050", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3711) },
                    { 45, "1051", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3764) },
                    { 46, "1052", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3767) },
                    { 47, "1053", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3768) },
                    { 48, "1054", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3769) },
                    { 49, "1055", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3770) },
                    { 50, "1056", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3771) },
                    { 51, "1057", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3772) },
                    { 52, "1058", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3772) },
                    { 53, "1059", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3773) },
                    { 54, "1060", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3774) },
                    { 55, "1061", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3776) },
                    { 56, "1062", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3776) },
                    { 57, "1063", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3777) },
                    { 58, "1064", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3778) },
                    { 59, "1065", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3779) },
                    { 60, "1066", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3780) },
                    { 61, "1067", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3781) },
                    { 62, "1068", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3782) },
                    { 63, "1072", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3783) },
                    { 64, "1073", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3784) },
                    { 65, "1075", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3785) },
                    { 66, "1078", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3786) },
                    { 67, "1081", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3787) },
                    { 68, "8015", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3788) },
                    { 69, "9039", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3789) },
                    { 70, "9040", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3790) },
                    { 71, "9044", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(3791) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 1, "egomez", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(4329), "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 2, "rnajm", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(4361), "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Alias", "CreationDateTime", "Password", "Rol", "StoreId" },
                values: new object[] { 3, "ag01", new DateTime(2023, 10, 11, 11, 38, 1, 531, DateTimeKind.Local).AddTicks(4446), "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "Store", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AudioList_StoreId",
                table: "AudioList",
                column: "StoreId");

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
                name: "AudioList");

            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
