using backend_api.Models.Tables.CommentData;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using backend_api.Models.Tables.ServiceData;
using backend_api.Models.Tables.UserData;

[Table("comment_reaction")]
public class CommentReaction
{
    [Column("_id")]
    [Key]
    public long Id { get; set; }

    [Column("comment_guid")]
    public Guid CommentGuid { get; set; }
    
    [Column("user_guid")]
    public Guid UserGuid { get; set; }

    [Column("type")]
    public short Type { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }
}
