using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.UserData

{
    [Table("user")]
    public class User
    {
        [Column("guid")]
        [Key]
        public Guid Guid { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Column("password")]
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("is_reported")]
        public bool IsReported { get; set; }

        [Column("is_banned")]
        public bool IsBanned { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
