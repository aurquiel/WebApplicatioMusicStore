using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities
{
    [Table("Registers")]
    public class RegisterEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("StoreEntity")]
        public int StoreId { get; set; }
        public virtual StoreEntity? StoreEntity { get; set; }

        [Required]
        public int Activity { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Message { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }
    }
}
