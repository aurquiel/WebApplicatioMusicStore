using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities
{
    [Table("Stores")]
    public class StoreEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public string? Code { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }
    }
}
