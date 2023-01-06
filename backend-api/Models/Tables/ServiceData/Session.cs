using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_api.Models.Tables.ServiceData
{
    [Table("session")]
    public class Session
    {
        [Column("_id")]
        [Key]
        public long Id { get; set; }
        
        [Column("guid")]
        public string Guid { get; set; }

        [Column("user_guid")]
        public string UserGuid { get; set; }

        [Column("session_key")]
        public string SessionKey { get; set; }

        [Column("created_at")]
        public string CreatedAt { get; set; }

        [Column("updated_at")]
        public string UpdatedAt { get; set; }
    }
}
