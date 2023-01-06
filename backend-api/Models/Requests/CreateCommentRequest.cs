using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Requests
{
    public class CreateCommentRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("post_guid")]
        public Guid PostGuid { get; set; }

        [Column("content")]
        [Required]
        public string Content { get; set; }
    }
}
