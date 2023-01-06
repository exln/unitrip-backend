using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Models.Requests
{
    public class MessageResponse
    {
        [Column("message")]
        public string Message { get; set; }
    }
    
    
}
