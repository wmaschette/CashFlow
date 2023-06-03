namespace CashFlow.SqlData;

using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(
        DbContextOptions<ApplicationDataContext> options
    ) : base(options)
    {
    }

    public DbSet<DailyEntry> DailyEntries { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<DailyEntry>()
          .HasKey(dailyEntry => new { dailyEntry.Id })
          .HasName("PK_DailyEntry");
    }
}
