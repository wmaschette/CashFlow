using CashFlow.Api.DTOs.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces.Repositories;

public interface IDailyEntryQueryRepository
{
    Task<IEnumerable<DailyEntriesConsolidatedResponseDto>> GetDailyEntriesConsolidatedByMonth(DateTime date);

    Task<DailyEntry> GetDailyEntryById(Guid dailyEntryId);

    Task<IEnumerable<DailyEntriesConsolidatedResponseDto>> GetDailyEntriesConsolidatedBetweenDates(DateTime startDate, DateTime endDate);
}
