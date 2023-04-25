using CommunityWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebApplication.Data
{
    public class CommunityAPIDbContext : DbContext
    {
        public CommunityAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Community> CommunityTable { get; set; }
    }
}
