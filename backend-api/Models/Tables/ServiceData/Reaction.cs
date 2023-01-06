using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Tables.ServiceData
{
[Table("reaction")]
public class Reaction
{
    [Column("_id")]
    [Key]
    public byte Id { get; set; }

    [Column("title", TypeName = "VARCHAR(20)")]
    [Required]
    [MaxLength(20)]
    public string Title { get; set; }
}
}