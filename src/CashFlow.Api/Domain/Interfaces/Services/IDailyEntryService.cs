using CashFlow.Domain.DTOs;

namespace CashFlow.Domain.Interfaces;

public interface IDailyEntryService
{
    Task<DailyEntryResponseDto> CreateDailyEntry(DailyEntryRequestDto dailyEntryRequest);

    Task<DailyEntryResponseDto?> GetDailyEntryById(Guid id);
}
