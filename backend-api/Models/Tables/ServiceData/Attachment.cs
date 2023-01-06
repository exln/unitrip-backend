using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.ServiceData
{
    [Table("attachments")]
    public class Attachment
    {
        [Column("_id")]
        [Key]
        public long Id { get; set; }

        [Column("url", TypeName = "VARCHAR(256)")]
        [Required]
        [MaxLength(256)]
        public string Url { get; set; }
    }
}
