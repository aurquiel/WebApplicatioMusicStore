using Microsoft.EntityFrameworkCore;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;
using WebApplicationMusicStore.DrivingAdapters.Utils;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters
{
    /*
     * MIGRATION COMMNAD
     Add-Migration InitialCreated -c AudioStoreDbContext -OutputDir "C:\Users\egomez\source\repos\WebApplicatioMusicStore\WebApplicatioMusicStore\DrivenAdapters\DatabaseAdapters\Migrations"
     */

    public class AudioStoreDbContext : DbContext
    {
        public AudioStoreDbContext(DbContextOptions<AudioStoreDbContext> options) : base(options)
        {
        }

        public AudioStoreDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AudioStore;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreEntity>(x =>
            {
                x.HasData(
                    new StoreEntity
                    {
                        Id = 1,
                        Code = "0000",
                        CreationDateTime = DateTime.Now
                    },
                    new StoreEntity
                    {
                        Id = 2,
                        Code = "1001",
                        CreationDateTime = DateTime.Now
                    },
                    new StoreEntity
                    {
                        Id = 3,
                        Code = "1002",
                        CreationDateTime = DateTime.Now
                    },
                    new StoreEntity
                    {
                        Id = 4,
                        Code = "1003",
                        CreationDateTime = DateTime.Now
                    },
                    new StoreEntity
                    {
                        Id = 5,
                        Code = "1004",
                        CreationDateTime = DateTime.Now
                    },
                    new StoreEntity
                    {
                        Id = 6,
                        Code = "1005",
                        CreationDateTime = DateTime.Now
                    },
                    new StoreEntity
                    {
                        Id = 7,
                        Code = "1006",
                        CreationDateTime = DateTime.Now
                    },
                    new StoreEntity
                    {
                        Id = 8,
                        Code = "1007",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 9,
                        Code = "1008",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 10,
                        Code = "1009",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 11,
                        Code = "1010",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 12,
                        Code = "1011",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 13,
                        Code = "1012",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 14,
                        Code = "1013",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 15,
                        Code = "1014",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 16,
                        Code = "1016",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 17,
                        Code = "1018",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 18,
                        Code = "1019",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 19,
                        Code = "1020",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 20,
                        Code = "1021",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 21,
                        Code = "1022",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 22,
                        Code = "1023",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 23,
                        Code = "1024",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 24,
                        Code = "1026",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 25,
                        Code = "1027",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 26,
                        Code = "1028",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 27,
                        Code = "1029",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 28,
                        Code = "1030",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 29,
                        Code = "1031",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 30,
                        Code = "1032",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 31,
                        Code = "1033",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 32,
                        Code = "1034",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 33,
                        Code = "1035",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 34,
                        Code = "1036",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 35,
                        Code = "1037",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 36,
                        Code = "1038",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 37,
                        Code = "1041",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 38,
                        Code = "1042",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 39,
                        Code = "1043",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 40,
                        Code = "1045",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 41,
                        Code = "1046",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 42,
                        Code = "1047",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 43,
                        Code = "1048",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 44,
                        Code = "1050",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 45,
                        Code = "1051",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 46,
                        Code = "1052",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 47,
                        Code = "1053",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 48,
                        Code = "1054",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 49,
                        Code = "1055",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 50,
                        Code = "1056",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 51,
                        Code = "1057",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 52,
                        Code = "1058",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 53,
                        Code = "1059",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 54,
                        Code = "1060",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 55,
                        Code = "1061",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 56,
                        Code = "1062",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 57,
                        Code = "1063",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 58,
                        Code = "1064",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 59,
                        Code = "1065",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 60,
                        Code = "1066",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 61,
                        Code = "1067",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 62,
                        Code = "1068",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 63,
                        Code = "1072",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 64,
                        Code = "1073",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 65,
                        Code = "1075",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 66,
                        Code = "1078",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 67,
                        Code = "1081",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 68,
                        Code = "8015",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 69,
                        Code = "9039",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 70,
                        Code = "9040",
                        CreationDateTime = DateTime.Now

                    },
                    new StoreEntity
                    {
                        Id = 71,
                        Code = "9044",
                        CreationDateTime = DateTime.Now

                    }
                );
            });

            modelBuilder.Entity<UserEntity>(x =>
            {
                x.HasData(
                    new UserEntity
                    {
                        Id = 1,
                        Alias = "egomez",
                        Password = Hash256.HashOfUserPassword("54001990"),
                        StoreId = 1,
                        Rol = "Admin",
                        CreationDateTime = DateTime.Now
                    },
                    new UserEntity
                    {
                        Id = 2,
                        Alias = "rnajm",
                        Password = Hash256.HashOfUserPassword("1234"),
                        StoreId = 1,
                        Rol = "Admin",
                        CreationDateTime = DateTime.Now
                    },
                    new UserEntity
                    {
                        Id = 3,
                        Alias = "ag01",
                        Password = Hash256.HashOfUserPassword("1234"),
                        StoreId = 2,
                        Rol = "Store",
                        CreationDateTime = DateTime.Now
                    }
                );
            });
        }

        public DbSet<RegisterEntity> RegistersEntity { get; set; }
        public DbSet<StoreEntity> StoresEntity { get; set; }
        public DbSet<UserEntity> UsersEntity { get; set; }
    }
}
