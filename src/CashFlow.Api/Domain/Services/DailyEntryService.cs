using CashFlow.Domain.DTOs;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Interfaces;
using Microsoft.Extensions.Logging;

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

    public async Task<DailyEntryResponseDto> CreateDailyEntry(DailyEntryRequestDto dailyEntryRequest)
    {
        ValidateDailyEntry(dailyEntryRequest);

        _logger.LogInformation("Creating daily entry");

        var dailyEntry = new DailyEntry(
            (OperationType)dailyEntryRequest.OperationTypeId, 
            dailyEntryRequest.Amount
            );

        var entity = await _dailyEntryRepository.Create(dailyEntry);
        if(entity is null)
        {
            _logger.LogError("Error creating daily entry");
            throw new Exception("Error on saving daily entry");
        }
        
        _logger.LogInformation("Daily entry created");

        var response = new DailyEntryResponseDto
        {
            Id = dailyEntry.Id,
            Date = dailyEntry.Date,
            OperationTypeId = (int)dailyEntry.OperationTypeId,
            Amount = dailyEntry.Amount
        };

        return response;
    }

public async Task<DailyEntryResponseDto?> GetDailyEntryById(Guid id)
{
    var entity = await _dailyEntryRepository.GetById(id);
    if(entity is null)
        return null;

    return new DailyEntryResponseDto
    {
        Id = entity.Id,
        Date = entity.Date,
        OperationTypeId = (int)entity.OperationTypeId,
        Amount = entity.Amount
    };
}
    public void ValidateDailyEntry(DailyEntryRequestDto dailyEntryRequest)
    {
        _logger.LogInformation("Validating daily entry");

        if (dailyEntryRequest.Amount <= 0){
            _logger.LogError("Amount must be greater than zero. Value received: {0}", dailyEntryRequest.Amount);
            throw new ArgumentException("Amount must be greater than zero.", nameof(dailyEntryRequest.Amount));
        }
            
        if (!Enum.IsDefined(typeof(OperationType), dailyEntryRequest.OperationTypeId))
        {
            _logger.LogError("Invalid operation type {0}.", dailyEntryRequest.OperationTypeId);
            throw new ArgumentException($"Invalid operation type.", nameof(dailyEntryRequest.OperationTypeId));
        }

        _logger.LogInformation("Daily entry validated");
    }
}
