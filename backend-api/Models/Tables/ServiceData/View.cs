using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_api.Models.Tables.ServiceData
{
    [Table("view")]
    public class View
    {
        [Column("_id")]
        [Key]
        public long Id { get; set; }

        [Column("post_guid")]
        public string PostGuid { get; set; }

        [Column("session_guid")]
        public string SessionGuid { get; set; }
  
        [Column("viewed_at")]
        public string ViewedAt { get; set; }

        [Column("reviewed_at")]
        public string ReviewedAt { get; set; }
    }
}
