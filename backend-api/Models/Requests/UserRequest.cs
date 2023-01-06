using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Requests
{
    public class UserRequest
    {
        [Column("email")]
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }
    }

    public class CreateUserRequest : UserRequest
    {
        [Column("password")]
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
    }

    public class UpdateUserRequest : UserRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("password")]
        [MaxLength(256)]
        public string Password { get; set; }    
    }

    public class UpdateUserPasswordRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("password")]
        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [Column("new_password")]
        [Required]
        [MaxLength(256)]
        public string NewPassword { get; set; }
    }

    public class UpdateUserActiveRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }
    }

    public class UpdateUserStatusRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("status")]
        public string Status { get; set; }
    }


    public class UserGet : UserRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("id")]
        public int Id { get; set; }

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

    public class UserIdRequest
    {
        [Column("id")]
        public int Id { get; set; }

    }

    public class UserGuidRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }
    }

    public class UserEmailRequest
    {
        [Column("email")]
        public string Email { get; set; }
    }

    public class UserNicknameRequest
    {
        [Column("nickname")]
        public string Nickname { get; set; }
    }

    public class UserSearch {
        [Column("nickname")]
        [MaxLength(30)]
        public string Nickname { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

    }

    public class DeleteUserRequest
    {
        [Column("user_guid")]
        public Guid UserGuid { get; set; }

        [Column("password")]
        [MaxLength(256)]
        public string Password { get; set; }

        [Column("email")]
        [MaxLength(256)]
        public string Email { get; set; }
    }
}
