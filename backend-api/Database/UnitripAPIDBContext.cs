using backend_api.Models.Tables.CommentData;
using backend_api.Models.Tables.PostData;
using backend_api.Models.Tables.PreferencesData;
using backend_api.Models.Tables.ServiceData;
using backend_api.Models.Tables.UserData;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_api.Database
{
    public class UnitripAPIDbContext : DbContext
    {
        public UnitripAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserMeta> UserMetas { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentMeta> CommentMetas { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<Post> Posts { get; set; }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().Property(p => p.Id).UseIdentity(100000000, 1);
        } */
        public DbSet<PostMeta> PostMetas { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<View> Views { get; set; }
        public DbSet<Report> Reports { get; set; }

    }
}
