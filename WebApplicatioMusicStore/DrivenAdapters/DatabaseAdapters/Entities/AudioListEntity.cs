using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities
{
    [Table("AudioList")]
    public class AudioListEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int Order { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("StoreEntity")]
        public int StoreId { get; set; }
        public StoreEntity StoreEntity { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public bool CheckForTime { get; set; }

        [Required]
        public TimeSpan TimeToPlay { get; set; }
    }
}
