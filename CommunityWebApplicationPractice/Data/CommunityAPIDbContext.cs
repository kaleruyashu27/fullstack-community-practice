
using CommunityWebApplicationPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityWebApplicationPractice.Data
{
    public class CommunityAPIDbContext : DbContext
    {
        public CommunityAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Community> CommunityTable { get; set; }

    }
}
