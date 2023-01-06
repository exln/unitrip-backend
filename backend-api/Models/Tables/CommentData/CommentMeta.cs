using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using backend_api.Models.Tables.ServiceData;

namespace backend_api.Models.Tables.CommentData
{
    public class CommentMeta
    {
        [Column("_id")]
        [Key]
        public long Id { get; set; }

        [Column("comment_guid")]
        public Guid CommentGuid { get; set; }

        [Column("attachment_full_id")]
        public long AttachmentFullId { get; set; }

        [Column("attachment_thumb_id")]
       public long AttachmentThumbId { get; set; }

    }

}
