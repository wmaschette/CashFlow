namespace CashFlow.Infrastructure;

using System.ComponentModel.DataAnnotations.Schema;
using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDataContext : DbContext
{
    public ApplicationDataContext(
        DbContextOptions<ApplicationDataContext> options
    ) : base(options)
    {
    }

    public DbSet<DailyEntry> dailyentries { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<DailyEntry>(
            dailyEntry =>
            {
                dailyEntry.ToTable("dailyentries")
                .HasKey(dailyEntry => new { dailyEntry.Id })
                .HasName("dailyentries_pkey");

                dailyEntry.Property(dailyEntry => dailyEntry.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

                dailyEntry.Property(dailyEntry => dailyEntry.CreatedAt)
                .HasColumnName("createdat")
                .HasColumnType("timestamp")
                .IsRequired();

                dailyEntry.Property(dailyEntry => dailyEntry.OperationTypeId)
                .HasColumnName("operationtypeid")
                .HasColumnType("smallint")
                .IsRequired();

                dailyEntry.Property(dailyEntry => dailyEntry.Amount)
                .HasColumnName("amount")
                .HasColumnType("numeric(10,2)")
                .IsRequired();
            }
            );
    }
}
