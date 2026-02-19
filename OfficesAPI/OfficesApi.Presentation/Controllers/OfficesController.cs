using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficesApi.Application.Offices.Create;
using OfficesApi.Application.Offices.Delete;
using OfficesApi.Application.Offices.GetAll;
using OfficesApi.Application.Offices.GetById;
using OfficesApi.Application.Offices.PartiallyUpdate;

namespace OfficesApi.Presentation.Controllers;

[Route("api/offices")]
[ApiController]
[ServiceFilter<TrackExecutionTimeAttribute>]
[Authorize("OfficesAuthPolicy")] 
public class OfficesController : ControllerBase
{
    private readonly ISender _sender;

    public OfficesController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Gets list of all offices
    /// </summary>
    /// <returns>List of offices</returns>
    [HttpGet]
    public async Task<ActionResult> GetAllOffices()
    {
        var offices = await _sender.Send(new GetAllOfficesQuery());
        return Ok(offices);
    }

    /// <summary>
    /// Gets one existing office by id
    /// </summary>
    /// <param name="id">Office Id</param>
    /// <returns>Office object</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetOfficeById(string id)
    {
        var office = await _sender.Send(new GetOfficeByIdQuery(id));
        return Ok(office);
    }

    /// <summary>
    /// Creates new office
    /// </summary>
    /// <param name="officeCreate">Object with fields to create a new office</param>
    /// <returns>New office object</returns>
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

    /// <summary>
    /// Partially updates existing office
    /// </summary>
    /// <param name="id">Office Id</param>
    /// <param name="updates">Dictionary of type: string-object, 
    /// where string - name of existing field,
    ///  obj - new value for it;
    /// { "IsActive" : false }</param>
    /// <returns>NoContent</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> PartiallyUpdateOffice(string id,
        [FromBody] Dictionary<string, object> updates)
    {
        await _sender.Send(new PartiallyUpdateOfficeCommand(id, updates));

        return NoContent();
    }
}