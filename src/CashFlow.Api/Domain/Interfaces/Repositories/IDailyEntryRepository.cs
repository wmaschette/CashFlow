namespace CashFlow.Domain.Interfaces;

using CashFlow.Domain.Entities;

public interface IDailyEntryRepository
{
    Task<DailyEntry> Create(DailyEntry dailyEntry);
    Task<DailyEntry?> GetById(Guid id);
}
