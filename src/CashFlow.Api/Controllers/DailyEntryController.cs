using CashFlow.Api.DTOs;
using CashFlow.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DailyEntryController : ControllerBase
{
    private readonly ILogger<DailyEntryController> _logger;
    private readonly IDailyEntryService _dailyEntryService;
    public DailyEntryController(ILogger<DailyEntryController> logger, IDailyEntryService dailyEntryService)
    {
        _logger = logger;
        _dailyEntryService = dailyEntryService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(DailyEntryResponseDto), 201)]
    public async Task<IActionResult> Post([FromBody] DailyEntryRequestDto dailyEntryRequest)
    {
        if (dailyEntryRequest == null)
        {
            _logger.LogWarning("DailyEntry object sent from client is null.");
            return BadRequest("DailyEntry object is null");
        }

        var dailyEntry = await _dailyEntryService.CreateDailyEntry(dailyEntryRequest.OperationTypeId, dailyEntryRequest.Amount);

        return Created(
            new Uri($"{Request.Path}/{dailyEntry.Id}", UriKind.Relative),
            new DailyEntryResponseDto
            {
                Id = dailyEntry.Id,
                OperationTypeId = (int)dailyEntry.OperationTypeId,
                Amount = dailyEntry.Amount,
                CreatedAt = dailyEntry.CreatedAt
            });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        _logger.LogInformation("Getting daily entry by id");

        var response = await _dailyEntryService.GetDailyEntryById(id);
        if (response is null)
            return NotFound();

        return Ok(response);
    }
}
