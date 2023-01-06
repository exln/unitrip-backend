using backend_api.Database;
using backend_api.Models.Requests;
using backend_api.Models.Tables.PostData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly UnitripAPIDbContext dbContext;
        public PostController(UnitripAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await dbContext.Posts.ToListAsync());
        }


        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
        {
            var post = new Post
            {
                Guid = Guid.NewGuid(),
                Id = 0,
                UserGuid = request.UserGuid,
                Title = request.Title,
                MetaTitle = request.Title,
                Content = request.Content,
                Summary = new string(request.Content.Take(250).ToArray()),
                //Slug = Transliteration.CyrillicToLatin(request.Title, Language.Russian).Replace(" ", "-"),
                Slug = request.Title.Replace(" ", "-"),
                IsPublished = false,
                IsReported = false,
                IsBanned = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                PublishedAt = DateTime.Now
            };
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return Ok(post);
        }
    }
}
