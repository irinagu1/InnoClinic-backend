using MediatR;
using Microsoft.AspNetCore.Mvc;
using OfficesApi.Application.Offices.Create;
using OfficesApi.Application.Offices.Delete;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Application.Offices.GetById;
using OfficesApi.Application.Offices.PartiallyUpdate;

namespace OfficesApi.Presentation.Controllers;

[Route("api/offices")]
[ApiController]
public class OfficesController : ControllerBase
{
    private readonly ISender _sender;

    public OfficesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllOffices()
    {
        var offices = await _sender.Send(new GetAllOfficesQuery());
        return Ok(offices);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetOfficeById(string id)
    {
        var office = await _sender.Send(new GetOfficeByIdQuery(id));
        return Ok(office);
    }

    [HttpPost]
    public async Task<ActionResult> CreateOffice([FromBody] OfficeCreate officeCreate)
    {
        var newOffice = await _sender.Send(new CreateOfficeCommand(officeCreate));
        return Ok(newOffice);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOfficeById(string id)
    {
        await _sender.Send(new DeleteOfficeByIdCommand(id));
        return NoContent();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PartiallyUpdateOffice(string id, 
        [FromBody] Dictionary<string,object> updates)
    {
        await _sender.Send(new PartiallyUpdateOfficeCommand(id, updates));

        return NoContent();
    }
}