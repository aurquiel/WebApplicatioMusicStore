using System.ComponentModel.DataAnnotations;

namespace WebApplicatioMusicStore.Database
{
    public class Store
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
