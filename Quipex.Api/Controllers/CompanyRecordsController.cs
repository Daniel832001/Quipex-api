using Microsoft.AspNetCore.Mvc;
using Quipex.Application.Commands;
using MediatR;
using Quipex.Api.Requests;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Quipex.Application.Queries;
using Quipex.Application.DTOs;
using Azure.Core;

namespace Quipex.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyRecordsController : ControllerBase
{

    private readonly ILogger<CompanyRecordsController> _logger;
    private readonly IMediator _mediator;

    public CompanyRecordsController(ILogger<CompanyRecordsController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompanyRecord([FromBody] CreateCompanyRecordRequest request)
    {
        var command = new CreateCompanyRecordCommand(request.Name, request.StockTicker, request.Exchange, request.ISIN, request.Website);
        await _mediator.Send(command);
        return StatusCode(201, new { message = "Successfully created new record." });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyRecordDto>> GetCompanyRecordById([FromRoute] long id)
    {
        var query = new GetCompanyRecordByIdQuery(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyRecordDto>>> GetCompanyRecords()
    {
        var query = new GetCompanyRecordsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCompanyRecord([FromBody] UpdateCompanyRecordRequest request)
    {
        var command = new UpdateCompanyRecordCommand(request.Id, request.Name, request.StockTicker, request.Exchange, request.ISIN, request.Website);
        await _mediator.Send(command);
        return NoContent();
    }
}
