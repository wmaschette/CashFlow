using System.Runtime.CompilerServices;
using CashFlow.Domain.Entities.Common;
using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities;

public class DailyEntry : BaseEntity
{
    public DailyEntry()
    {
    }

    public DateTime Date { get; private set; }
    public OperationType OperationTypeId { get; private set; }
    public decimal Amount { get; private set; }

    public DailyEntry(OperationType operationType, decimal amount)
    {
        Date = DateTime.Now;
        OperationTypeId = operationType;
        Amount = amount;
    }
}
