using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_api.Models.Tables.PostData
{
    [Table("post_reaction")]
    public class PostReaction
    {
        [Column("_id")]
        [Key]
        public int Id { get; set; }
        
        [Column("post_guid")]
        public Guid PostGuid { get; set; }
        
        [Column("user_guid")]
        public Guid UserGuid { get; set; }
        
        [Column("type")]
        public byte Type { get; set; }
        
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
