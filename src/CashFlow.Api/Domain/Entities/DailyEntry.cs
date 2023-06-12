using CashFlow.Domain.Entities.Common;
using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities;

public class DailyEntry : BaseEntity
{
    public DateTime CreatedAt { get; private set; }
    public OperationType OperationTypeId { get; private set; }
    public decimal Amount { get; private set; }

    public DailyEntry() { } // EF Core

    public DailyEntry(OperationType operationType, decimal amount)
    {
        CreatedAt = DateTime.Now;
        OperationTypeId = operationType;
        Amount = amount;
    }
}
