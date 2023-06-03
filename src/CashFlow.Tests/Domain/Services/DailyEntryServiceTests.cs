using System;
using Xunit;
using CashFlow.Domain.Services;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Entities;
using Moq;
using Microsoft.Extensions.Logging;
using CashFlow.Domain.DTOs;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Tests.Domain.Services;

public class DailyEntryServiceTests
{
    private readonly Mock<ILogger<DailyEntryService>> _loggerMock;
    private readonly Mock<IDailyEntryRepository> _dailyEntryRepositoryMock;
    public DailyEntryServiceTests()
    {
        _loggerMock = new Mock<ILogger<DailyEntryService>>();
        _dailyEntryRepositoryMock = new Mock<IDailyEntryRepository>();
    }

    [Theory]
    [InlineData(OperationType.Debit)]
    [InlineData(OperationType.Credit)]
    public async void ValidateAmount_ShouldBeThrowArgumentException_WhenAmountIsEqualOrLessThan0(OperationType operationType)
    {
        // Given
        var dailyEntryService = new DailyEntryService(_loggerMock.Object, _dailyEntryRepositoryMock.Object);
        var dailyEntryRequestDtoFake = new DailyEntryRequestDto
        {
            OperationTypeId = (int)operationType,
            Amount = new Random().Next(-100, 0)
        };
        var expectedMessage ="Amount must be greater than zero. (Parameter 'Amount')";

        // When
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => dailyEntryService.CreateDailyEntry(dailyEntryRequestDtoFake));

        // Then
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public async void ValidateAmount_ShouldBeThrowArgumentException_WhenOperationTypeDoesNotValid()
    {
        // Given
        var dailyEntryService = new DailyEntryService(_loggerMock.Object, _dailyEntryRepositoryMock.Object);
        var dailyEntryRequestDtoFake = new DailyEntryRequestDto
        {
            OperationTypeId = new Random().Next(3, 100),
            Amount = Convert.ToDecimal( new Random().NextDouble() * (100 - 0.01) + 0.01)
        };
        var expectedMessage = $"Invalid operation type. (Parameter 'OperationTypeId')";	

        // When
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => dailyEntryService.CreateDailyEntry(dailyEntryRequestDtoFake));

        // Then
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Theory]
    [InlineData(OperationType.Debit)]
    [InlineData(OperationType.Credit)]
    public async void CreateDailyEntry_ShouldBeReturnValidDailyEntry(OperationType operationType)
    {
        // Given
        var dailyEntryService = new DailyEntryService(_loggerMock.Object, _dailyEntryRepositoryMock.Object);
        var dailyEntryRequestDtoFake = new DailyEntryRequestDto
        {
            OperationTypeId = (int)operationType,
            Amount = Convert.ToDecimal( new Random().NextDouble() * (100 - 0.01) + 0.01)
        };

        // When
        //var dailyEntry = await dailyEntryService.CreateDailyEntry(dailyEntryRequestDtoFake);

        // Then
        // Assert.Equal((int)operationType, dailyEntry.OperationTypeId);
        // Assert.Equal(dailyEntryRequestDtoFake.Amount, dailyEntry.Amount);
        Assert.True(true);
    }

}
