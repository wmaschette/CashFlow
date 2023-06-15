using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces;

public interface IDailyEntryService
{
    Task<DailyEntry> CreateDailyEntry(int operationTypeId, decimal amount);
}
