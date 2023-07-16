using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicatioMusicStore.Database
{
    public class User
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
        [ForeignKey("Id")]
        public int StoreId { get; set; }
        public virtual Store? Stores { get; set; }

        [Required]
        [StringLength(50)]
        public string? Rol { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }

    }
}
