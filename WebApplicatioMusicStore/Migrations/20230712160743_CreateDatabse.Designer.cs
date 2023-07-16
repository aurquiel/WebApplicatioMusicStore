﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicatioMusicStore.Database;

#nullable disable

namespace WebApplicatioMusicStore.Migrations
{
    [DbContext(typeof(AudioStoreContext))]
    [Migration("20230712160743_CreateDatabse")]
    partial class CreateDatabse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplicatioMusicStore.Database.Register", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Registers");
                });

            modelBuilder.Entity("WebApplicatioMusicStore.Database.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "0000",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6570)
                        },
                        new
                        {
                            Id = 2,
                            Code = "1001",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6593)
                        },
                        new
                        {
                            Id = 3,
                            Code = "1002",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6594)
                        },
                        new
                        {
                            Id = 4,
                            Code = "1003",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6595)
                        },
                        new
                        {
                            Id = 5,
                            Code = "1004",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6596)
                        },
                        new
                        {
                            Id = 6,
                            Code = "1005",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6597)
                        },
                        new
                        {
                            Id = 7,
                            Code = "1006",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6598)
                        },
                        new
                        {
                            Id = 8,
                            Code = "1007",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6599)
                        },
                        new
                        {
                            Id = 9,
                            Code = "1008",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6600)
                        },
                        new
                        {
                            Id = 10,
                            Code = "1009",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6601)
                        },
                        new
                        {
                            Id = 11,
                            Code = "1010",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6602)
                        },
                        new
                        {
                            Id = 12,
                            Code = "1011",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6603)
                        },
                        new
                        {
                            Id = 13,
                            Code = "1012",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6604)
                        },
                        new
                        {
                            Id = 14,
                            Code = "1013",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6605)
                        },
                        new
                        {
                            Id = 15,
                            Code = "1014",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6606)
                        },
                        new
                        {
                            Id = 16,
                            Code = "1016",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6606)
                        },
                        new
                        {
                            Id = 17,
                            Code = "1018",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6607)
                        },
                        new
                        {
                            Id = 18,
                            Code = "1019",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6608)
                        },
                        new
                        {
                            Id = 19,
                            Code = "1020",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6609)
                        },
                        new
                        {
                            Id = 20,
                            Code = "1021",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6610)
                        },
                        new
                        {
                            Id = 21,
                            Code = "1022",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6611)
                        },
                        new
                        {
                            Id = 22,
                            Code = "1023",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6612)
                        },
                        new
                        {
                            Id = 23,
                            Code = "1024",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6613)
                        },
                        new
                        {
                            Id = 24,
                            Code = "1026",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6614)
                        },
                        new
                        {
                            Id = 25,
                            Code = "1027",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6615)
                        },
                        new
                        {
                            Id = 26,
                            Code = "1028",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6616)
                        },
                        new
                        {
                            Id = 27,
                            Code = "1029",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6617)
                        },
                        new
                        {
                            Id = 28,
                            Code = "1030",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6618)
                        },
                        new
                        {
                            Id = 29,
                            Code = "1031",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6619)
                        },
                        new
                        {
                            Id = 30,
                            Code = "1032",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6619)
                        },
                        new
                        {
                            Id = 31,
                            Code = "1033",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6620)
                        },
                        new
                        {
                            Id = 32,
                            Code = "1034",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6621)
                        },
                        new
                        {
                            Id = 33,
                            Code = "1035",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6622)
                        },
                        new
                        {
                            Id = 34,
                            Code = "1036",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6623)
                        },
                        new
                        {
                            Id = 35,
                            Code = "1037",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6624)
                        },
                        new
                        {
                            Id = 36,
                            Code = "1038",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6625)
                        },
                        new
                        {
                            Id = 37,
                            Code = "1041",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6626)
                        },
                        new
                        {
                            Id = 38,
                            Code = "1042",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6627)
                        },
                        new
                        {
                            Id = 39,
                            Code = "1043",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6628)
                        },
                        new
                        {
                            Id = 40,
                            Code = "1045",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6629)
                        },
                        new
                        {
                            Id = 41,
                            Code = "1046",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6630)
                        },
                        new
                        {
                            Id = 42,
                            Code = "1047",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6631)
                        },
                        new
                        {
                            Id = 43,
                            Code = "1048",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6632)
                        },
                        new
                        {
                            Id = 44,
                            Code = "1050",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6633)
                        },
                        new
                        {
                            Id = 45,
                            Code = "1051",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6633)
                        },
                        new
                        {
                            Id = 46,
                            Code = "1052",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6634)
                        },
                        new
                        {
                            Id = 47,
                            Code = "1053",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6635)
                        },
                        new
                        {
                            Id = 48,
                            Code = "1054",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6636)
                        },
                        new
                        {
                            Id = 49,
                            Code = "1055",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6637)
                        },
                        new
                        {
                            Id = 50,
                            Code = "1056",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6638)
                        },
                        new
                        {
                            Id = 51,
                            Code = "1057",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6639)
                        },
                        new
                        {
                            Id = 52,
                            Code = "1058",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6640)
                        },
                        new
                        {
                            Id = 53,
                            Code = "1059",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6641)
                        },
                        new
                        {
                            Id = 54,
                            Code = "1060",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6642)
                        },
                        new
                        {
                            Id = 55,
                            Code = "1061",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6643)
                        },
                        new
                        {
                            Id = 56,
                            Code = "1062",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6644)
                        },
                        new
                        {
                            Id = 57,
                            Code = "1063",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6645)
                        },
                        new
                        {
                            Id = 58,
                            Code = "1064",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6645)
                        },
                        new
                        {
                            Id = 59,
                            Code = "1065",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6646)
                        },
                        new
                        {
                            Id = 60,
                            Code = "1066",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6647)
                        },
                        new
                        {
                            Id = 61,
                            Code = "1067",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6648)
                        },
                        new
                        {
                            Id = 62,
                            Code = "1068",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6651)
                        },
                        new
                        {
                            Id = 63,
                            Code = "1072",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6652)
                        },
                        new
                        {
                            Id = 64,
                            Code = "1073",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6652)
                        },
                        new
                        {
                            Id = 65,
                            Code = "1075",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6653)
                        },
                        new
                        {
                            Id = 66,
                            Code = "1078",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6654)
                        },
                        new
                        {
                            Id = 67,
                            Code = "1081",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6655)
                        },
                        new
                        {
                            Id = 68,
                            Code = "8015",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6656)
                        },
                        new
                        {
                            Id = 69,
                            Code = "9039",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6657)
                        },
                        new
                        {
                            Id = 70,
                            Code = "9040",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6658)
                        },
                        new
                        {
                            Id = 71,
                            Code = "9044",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(6659)
                        });
                });

            modelBuilder.Entity("WebApplicatioMusicStore.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "egomez",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(7103),
                            Password = "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87",
                            Rol = "Admin",
                            StoreId = 1
                        },
                        new
                        {
                            Id = 2,
                            Alias = "ag01",
                            CreationDateTime = new DateTime(2023, 7, 12, 12, 7, 42, 922, DateTimeKind.Local).AddTicks(7172),
                            Password = "09f2c49baa326fdc1a1fcd95934bc9e18e351263a4c2ca862f5abe9c83ec8f87",
                            Rol = "Store",
                            StoreId = 2
                        });
                });

            modelBuilder.Entity("WebApplicatioMusicStore.Database.Register", b =>
                {
                    b.HasOne("WebApplicatioMusicStore.Database.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebApplicatioMusicStore.Database.User", b =>
                {
                    b.HasOne("WebApplicatioMusicStore.Database.Store", "Stores")
                        .WithMany()
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stores");
                });
#pragma warning restore 612, 618
        }
    }
}
