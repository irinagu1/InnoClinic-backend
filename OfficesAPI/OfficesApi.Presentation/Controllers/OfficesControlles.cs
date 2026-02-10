using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficesApi.Application.Queries.GetOfficesQuery;
using OfficesApi.Domain.Entities;

[ApiController]
[Route("api/offices")]
public class OfficesController : ControllerBase
{
    private readonly ISender _sender;
    
    public OfficesController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Office>>> Get()
    {
        var result = await _sender.Send(new GetOfficesQuery());

        return Ok(result);
    }
}