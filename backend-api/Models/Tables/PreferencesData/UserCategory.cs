using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_api.Models.Tables.PreferencesData
{
    [Table("user_category")]
    public class UserCategory
    {
        [Column("_id")]
        [Key]
        public long Id { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
    }
}
