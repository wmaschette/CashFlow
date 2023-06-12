using System.Data;
using CashFlow.Api.DTOs.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Repositories;
using Dapper;
using Npgsql;


namespace CashFlow.Infrastructure.Queries;

public class DailyEntryQueryRepository : IDailyEntryQueryRepository, IDisposable
{
    private readonly IDbConnection _databaseConnection;

    public DailyEntryQueryRepository(string connectionString)
    {
        _databaseConnection = new NpgsqlConnection(connectionString);
        _databaseConnection.Open();
    }

    public void Dispose() => _databaseConnection.Dispose();

    public async Task<DailyEntry> GetDailyEntryById(Guid dailyEntryId)
    {
        var dailyEntry = await _databaseConnection.QueryFirstOrDefaultAsync<DailyEntry>(
            "SELECT * FROM DailyEntries WHERE Id = @Id",
            new { Id = dailyEntryId });

        return dailyEntry;
    }

    public async Task<IEnumerable<DailyEntriesConsolidatedResponseDto>> GetDailyEntriesConsolidatedBetweenDates(DateTime startDate, DateTime endDate)
    {
        var dailyEntries = await _databaseConnection.QueryAsync<DailyEntriesConsolidatedResponseDto>(
            "SELECT OperationTypeId, CASE WHEN OperationTypeId = 1 THEN -SUM(Amount) ELSE SUM(Amount) END AS Amount FROM DailyEntries WHERE CreatedAt BETWEEN @StartDate AND @EndDate GROUP BY OperationTypeId",
            new { StartDate = startDate, EndDate = endDate });

        return dailyEntries;
    }

    public async Task<IEnumerable<DailyEntriesConsolidatedResponseDto>> GetDailyEntriesConsolidatedByMonth(DateTime date)
    {
        var dailyEntries = await _databaseConnection.QueryAsync<DailyEntriesConsolidatedResponseDto>(
            "SELECT OperationTypeId, CASE WHEN OperationTypeId = 1 THEN -SUM(Amount) ELSE SUM(Amount) END AS Amount FROM DailyEntries WHERE DATE_TRUNC('month', CreatedAt) = DATE_TRUNC('month', @Date) GROUP BY OperationTypeId",
            new { Date = date });

        return dailyEntries;
    }

}
