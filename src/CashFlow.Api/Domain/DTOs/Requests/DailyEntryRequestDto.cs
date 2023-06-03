using System.ComponentModel.DataAnnotations;
using CashFlow.Domain.Enums;

namespace CashFlow.Domain.DTOs;

public class DailyEntryRequestDto
{
    [Required]
    [EnumDataType(typeof(OperationType), ErrorMessage = "Operation type must be 1 (Debit) or 2 (Credit).")]
    public int OperationTypeId { get; set; }

    [Required]
    [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }
}
