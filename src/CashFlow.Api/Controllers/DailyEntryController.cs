using CashFlow.Domain.DTOs;
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

        var response = await _dailyEntryService.CreateDailyEntry(dailyEntryRequest);

        return Created(new Uri($"{Request.Path}/{response.Id}", UriKind.Relative), response);
    } 

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        _logger.LogInformation("Getting daily entry by id");

        var response = await _dailyEntryService.GetDailyEntryById(id);
        if(response is null)
            return NotFound();

        return Ok(response);
    }
}
