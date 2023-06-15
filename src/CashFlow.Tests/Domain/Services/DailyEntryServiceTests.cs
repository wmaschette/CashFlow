using System;
using Xunit;
using CashFlow.Domain.Services;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Entities;
using Moq;
using Microsoft.Extensions.Logging;
using CashFlow.Domain.Interfaces;
using System.Threading.Tasks;

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
        var expectedMessage ="Amount must be greater than zero. (Parameter 'amount')";
        var amoutFake = new Random().Next(-100, 0);

        // When
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => dailyEntryService.CreateDailyEntry((int)operationType, amoutFake));

        // Then
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public async void ValidateOperationType_ShouldBeThrowArgumentException_WhenOperationTypeDoesNotValid()
    {
        // Given
        var dailyEntryService = new DailyEntryService(_loggerMock.Object, _dailyEntryRepositoryMock.Object);
        var operationTypeIdFake = new Random().Next(3, 100);
        var amoutFake = Convert.ToDecimal( new Random().NextDouble() * (100 - 0.01) + 0.01);
        var expectedMessage = $"Invalid operation type. (Parameter 'operationTypeId')";	

        // When
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => dailyEntryService.CreateDailyEntry(operationTypeIdFake, amoutFake));

        // Then
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Theory]
    [InlineData(OperationType.Debit)]
    [InlineData(OperationType.Credit)]
    public async void ValidateEntityCreated_ShouldBeThrowException_WhenCantSaveDailyEntryInDatabase(OperationType operationType)
    {
        // Given
        var expectedMessage = $"Error on saving daily entry')";	
        _dailyEntryRepositoryMock.Setup(x => x.Create(It.IsAny<DailyEntry>())).ThrowsAsync(new Exception(expectedMessage));
        var dailyEntryService = new DailyEntryService(_loggerMock.Object, _dailyEntryRepositoryMock.Object);
        var amoutFake = Convert.ToDecimal( new Random().NextDouble() * (100 - 0.01) + 0.01);

        // When
        var exception = await Assert.ThrowsAsync<Exception>(() => dailyEntryService.CreateDailyEntry((int)operationType, amoutFake));

        // Then
        Assert.Equal(expectedMessage, exception.Message);
    }

    [Theory]
    [InlineData(OperationType.Debit)]
    [InlineData(OperationType.Credit)]
    public async void CreateDailyEntry_ShouldBeReturnValidDailyEntry(OperationType operationType)
    {
        // Given
        var amoutFake = Convert.ToDecimal( new Random().NextDouble() * (100 - 0.01) + 0.01);
        _dailyEntryRepositoryMock
            .Setup(x => x.Create(It.IsAny<DailyEntry>()))
            .ReturnsAsync(new DailyEntry(operationType, amoutFake));
        var dailyEntryService = new DailyEntryService(_loggerMock.Object, _dailyEntryRepositoryMock.Object);

        // When
        var dailyEntry = await dailyEntryService.CreateDailyEntry((int)operationType, amoutFake);

        // Then
        Assert.Equal(operationType, dailyEntry.OperationTypeId);
        Assert.Equal(amoutFake, dailyEntry.Amount);
        Assert.True(true);
    }
}
