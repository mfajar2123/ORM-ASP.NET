using Microsoft.EntityFrameworkCore;

namespace UserCommentsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Pastikan nama DbSet sesuai dengan entitas yang digunakan
        public DbSet<UserComment> UserComments { get; set; }
    }

    public class UserComment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
