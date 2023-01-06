using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using backend_api.Models.Tables.UserData;

namespace backend_api.Models.Tables.CommentData
{
    public class Comment
    {
        [Column("guid")]
        [Key]
        public Guid Guid { get; set; }

        [Column("_id")]
        public int Id { get; set; }

        [Column("comment_id")]
        public int CommentId { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("post_guid")]
        public Guid PostGuid { get; set; }

        [Column("parent_guid")]
        public Guid ParentGuid { get; set; }

        [Column("content", TypeName = "VARCHAR(1000)")]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Column("is_published")]
        public bool IsPublished { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
        
        [Column("published_at")]
        public DateTime PublishedAt { get; set; }
    }
}
