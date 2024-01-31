using Microsoft.EntityFrameworkCore;
using HMS.WebApp.Models;

namespace HMS.WebApp.DatabaseContest;

public class ApplicationDbContest(DbContextOptions<ApplicationDbContest> contextOptions) : DbContext(contextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContest).Assembly);
    }

public DbSet<HMS.WebApp.Models.Doctor> Doctor { get; set; } = default!;
}
