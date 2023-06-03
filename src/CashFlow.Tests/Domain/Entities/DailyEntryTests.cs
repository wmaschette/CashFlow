using System;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using Xunit;

namespace CashFlow.Tests.Domain.Entities;

public class DailyEntryTests
{
    [Theory]
    [InlineData(OperationType.Debit)]
    [InlineData(OperationType.Credit)]
    public void Constructor_ShouldBeReturnValidDailyEntry(OperationType operationType)
    {
        // Given
        var randomAmount = new Random().Next(1, 100);

        // When
        var dailyEntry = new DailyEntry(operationType, randomAmount);

        // Then
        Assert.NotNull(dailyEntry);
        Assert.Equal(operationType, dailyEntry.OperationTypeId);
        Assert.Equal(randomAmount, dailyEntry.Amount);
        Assert.NotEqual(Guid.Empty, dailyEntry.Id);
        Assert.NotEqual(DateTime.MinValue, dailyEntry.Date);
    }
}
