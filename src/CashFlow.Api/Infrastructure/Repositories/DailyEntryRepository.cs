namespace CashFlow.Infrastructure.Repositories;

using CashFlow.Infrastructure;
using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CashFlow.Domain.Interfaces;

public class DailyEntryRepository : IDailyEntryRepository
{
    private readonly DbContext _applicationDataContext;
    private readonly DbSet<DailyEntry> _dailyEntries;

    public DailyEntryRepository(ApplicationDataContext applicationDataContext)
    {
        _applicationDataContext = applicationDataContext;
        _dailyEntries = _applicationDataContext.Set<DailyEntry>();
    }

    public async Task<DailyEntry> Create(DailyEntry dailyEntry)
    {
        _dailyEntries.Add(dailyEntry);
        await _applicationDataContext.SaveChangesAsync();
        return dailyEntry;
    }
}