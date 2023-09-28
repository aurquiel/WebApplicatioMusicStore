using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Alias { get; set; }

        [Required]
        [StringLength(300)]
        public string? Password { get; set; }

        [Required]
        [ForeignKey("StoreEntity")]
        public int StoreId { get; set; }
        public StoreEntity StoreEntity { get; set; }    

        [Required]
        [StringLength(50)]
        public string? Rol { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }
    }
}
