using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.PostData
{
    [Table("post_categories")]
    public class PostCategory
    {
        [Column("guid")]
        [Key]
        public Guid Guid { get; set; }

        [Column("post_guid")]
        public Guid PostGuid { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
    }
}
