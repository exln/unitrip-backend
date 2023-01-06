using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.PostData
{
    [Table("post")]
    public class Post
    {
        [Column("guid")]
        [Key]
        public Guid Guid { get; set; }

        [Column("_id")]
        public int Id { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("title", TypeName = "VARCHAR(75)")]
        [Required]
        [MaxLength(75)]
        public string Title { get; set; }

        [Column("meta_title", TypeName = "VARCHAR(100)")]
        [Required]
        [MaxLength(100)]
        public string MetaTitle { get; set; }

        [Column("summary", TypeName = "VARCHAR(256)")]
        [Required]
        [MaxLength(256)]
        public string Summary { get; set; }

        [Column("content")]
        [Required]
        public string Content { get; set; }

        [Column("slug", TypeName = "VARCHAR(100)")]
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }

        [Column("is_published")]
        [Required]
        public bool IsPublished { get; set; }

        [Column("is_reported")]
        [Required]
        public bool IsReported { get; set; }

        [Column("is_banned")]
        [Required]
        public bool IsBanned { get; set; }

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        [Required]
        public DateTime UpdatedAt { get; set; }

        [Column("published_at")]
        [Required]
        public DateTime PublishedAt { get; set; }


    }
}
