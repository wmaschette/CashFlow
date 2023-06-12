namespace CashFlow.Api.DTOs;

public class DailyEntryResponseDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int OperationTypeId { get; set; }
    public decimal Amount { get; set; }
}
