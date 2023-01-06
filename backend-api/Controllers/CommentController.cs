using backend_api.Database;
using backend_api.Models.Requests;
using backend_api.Models.Tables.CommentData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly UnitripAPIDbContext dbContext;
        public CommentController(UnitripAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            return Ok(await dbContext.Comments.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequest request)
        {
            var comment = new Comment
            {
                Guid = Guid.NewGuid(),
                Id = 0,
                CommentId = 0,
                UserGuid = request.UserGuid,
                PostGuid = request.PostGuid,
                ParentGuid = request.PostGuid,
                Content = request.Content,
                IsPublished = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                PublishedAt = DateTime.Now
            };
            await dbContext.Comments.AddAsync(comment);
            await dbContext.SaveChangesAsync();
            return Ok(comment);
        }

    }
}
