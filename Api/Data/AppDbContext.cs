using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserScore> UserScore { get; set; }

    // Define DbSets for your entities here
    // Example:
    // public DbSet<EntityName> EntityNames { get; set; }
}
