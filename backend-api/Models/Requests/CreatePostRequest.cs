using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace backend_api.Models.Requests
{
    public class CreatePostRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("title", TypeName = "VARCHAR(75)")]
        [Required]
        [MaxLength(75)]
        public string Title { get; set; }

        [Column("content")]
        [Required]
        public string Content { get; set; }
    }
}
