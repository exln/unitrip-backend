using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend_api.Models.Tables.ServiceData
{
    [Table("report")]
    public class Report
    {
        [Key]
        [Column("_id")]
        public long Id { get; set; }

        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("reported_content_guid")]
        public Guid ReportedContentGuid { get; set; }

        [Column("reported_content_type")]
        public byte ReportedContentType { get; set; }

        [Column("reason")]
        public string Reason { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
