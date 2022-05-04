using Microsoft.EntityFrameworkCore;
using PlayerService.Models;

namespace PlayerService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }
        public DbSet<Player> Player { get; set; }
    }
}