using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.UserData
{
    [Table("user_meta")]
    public class UserMeta
    {
        [Column("_id")]
        [Key]
        public int Id { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("nickname", TypeName = "VARCHAR(30)")]
        [MaxLength(30)]
        public string Nickname { get; set; }

        [Column("pfp_full_url")]
        public long PfpFullUrl { get; set; }

        [Column("pfp_thumb_url")]
        public long PfpThumbUrl { get; set; }

        [Column("bio", TypeName = "VARCHAR(1000)")]
        [MaxLength(1000)]
        public string Bio { get; set; }

        [Column("last_seen")]
        public DateTime LastSeen { get; set; }

        [Column("location")]
        public string Location { get; set; }

        [Column("website", TypeName = "VARCHAR(256)")]
        [MaxLength(256)]
        public string Website { get; set; }

        [Column("birthday")]
        public DateOnly Birthday { get; set; }
    }
}
