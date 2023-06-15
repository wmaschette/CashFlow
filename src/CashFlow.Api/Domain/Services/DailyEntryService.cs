using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Domain.Services;

public class DailyEntryService : IDailyEntryService
{
    private readonly ILogger<DailyEntryService> _logger;
    private readonly IDailyEntryRepository _dailyEntryRepository;
    public DailyEntryService(ILogger<DailyEntryService> logger, IDailyEntryRepository dailyEntryRepository)
    {
        _dailyEntryRepository = dailyEntryRepository;
        _logger = logger;
    }

    public async Task<DailyEntry> CreateDailyEntry(int operationTypeId, decimal amount)
    {
        _logger.LogInformation("Validating daily entry");

        if (amount <= 0)
        {
            _logger.LogError("Amount must be greater than zero. Value received: {0}", amount);
            throw new ArgumentException("Amount must be greater than zero.", nameof(amount));
        }

        if (!Enum.IsDefined(typeof(OperationType), operationTypeId))
        {
            _logger.LogError("Invalid operation type {0}.", operationTypeId);
            throw new ArgumentException($"Invalid operation type.", nameof(operationTypeId));
        }

        _logger.LogInformation("Daily entry validated");
        _logger.LogInformation("Creating daily entry");

        var dailyEntry = new DailyEntry(
            (OperationType)operationTypeId,
            amount
            );

        var entity = await _dailyEntryRepository.Create(dailyEntry);

        _logger.LogInformation("Daily entry created");

        return entity;
    }
}
