using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.PreferencesData
{
    [Table("user_tag")]
    public class UserTag
    {
        [Column("_id")]
        [Key]
        public long Id { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("tag_id")]
        public int TagId { get; set; }
    }
}
