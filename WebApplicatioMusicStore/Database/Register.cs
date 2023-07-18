using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicatioMusicStore.Database
{
    public class Register
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int StoreId { get; set; }
        public virtual Store? Stores { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }
    }
}
