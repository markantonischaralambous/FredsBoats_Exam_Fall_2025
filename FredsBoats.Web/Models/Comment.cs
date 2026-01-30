using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FredsBoats.Web.Models
{
    [Table("comment")]
    public class Comment
    {
        [Key]
        [Column("commentid")]
        public int BoatId { get; set; }

        [Column("content")]
        [StringLength(50)]
        public string Content { get; set; } = string.Empty;

        [Column("author")]
        [StringLength(50)]
        public string Author { get; set; } = string.Empty;

        [Column("createdat")]
        public DateTime Createdat { get; set; }

        // Foreign Keys
        [Column("fkcategoryid")]
        public int CategoryId { get; set; }
        
        [ForeignKey("BoatId")]
        public Boat? Boat { get; set; }

        [Column("fkboatid")]
        public int BoatId { get; set; }

        // Navigation for Boat
        public ICollection<Boat> Boat { get; set; } = new List<Boat>();
    }
}