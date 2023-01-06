using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.PostData
{
    [Table("post_tags")]
    public class PostTag
    {
        [Column("guid")]
        [Key]
        public Guid Guid { get; set; }

        [Column("post_guid")]
        public Guid PostGuid { get; set; }

        [Column("tag_id")]
        public int TagId { get; set; }
    }
}
