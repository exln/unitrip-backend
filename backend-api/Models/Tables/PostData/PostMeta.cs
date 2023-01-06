using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.PostData
{
    [Table("post_meta")]
    public class PostMeta
    {
        [Column("guid")]
        [Key]
        public Guid Guid { get; set; }

        [Column("post_guid")]
        public Guid PostGuid { get; set; }

        [Column("meta_key", TypeName = "VARCHAR(100)")]
        [Required]
        [MaxLength(100)]
        public string MetaKey { get; set; }
        
        [Column("attachment_full_url_id", TypeName = "VARCHAR(256)")]
        [MaxLength(256)]
        public int AttachmentFullUrlId { get; set; }

        [Column("attachment_thumb_url_id", TypeName = "VARCHAR(256)")]
        [MaxLength(256)]
        public int AttachmentThumbUrlId { get; set; }



    }
}
