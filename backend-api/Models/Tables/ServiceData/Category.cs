using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_api.Models.Tables.ServiceData
{
    public class Category
    {
        [Column("_id")]
        [Key]
        public int Id { get; set; }

        [Column("parent_id")]
        public int ParentId { get; set; }

        [Column("title", TypeName = "VARCHAR(75)")]
        [Required]
        [MaxLength(75)]
        public string Title { get; set; }

        [Column("slug", TypeName = "VARCHAR(100)")]
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; }

        [Column("content", TypeName = "VARCHAR(1000)")]
        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        [Column("meta_title", TypeName = "VARCHAR(100)")]
        [MaxLength(100)]
        public string MetaTitle { get; set; }
        [Column("meta_description", TypeName = "VARCHAR(1000)")]
        [MaxLength(1000)]
        public string MetaDescription { get; set; }
    }
}
