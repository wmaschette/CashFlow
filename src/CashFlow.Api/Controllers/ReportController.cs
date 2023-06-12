using CashFlow.Api.DTOs.Responses;
using CashFlow.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IDailyEntryQueryRepository _dailyEntryQueryRepository;
    public ReportController(IDailyEntryQueryRepository dailyEntryQueryRepository)
    {
        _dailyEntryQueryRepository = dailyEntryQueryRepository;
    }

    [HttpGet("consolidated")]
    [ProducesResponseType(typeof(DailyEntriesConsolidatedResponseDto), 200)]
    public async Task<IActionResult> GetConsolidated(DateTime startDate, DateTime endDate)
    {
        var response = await _dailyEntryQueryRepository.GetDailyEntriesConsolidatedBetweenDates(startDate, endDate);
        if(response == null || response.Count() == 0)
            return NotFound();

        return Ok(response);
    }
}
