using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Dtos;
using Shared.RequestFeatures;

namespace ProfilesApi.Presentation.Controllers;

[Route("api/doctors")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public DoctorsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDoctors([FromQuery] DoctorParameters parameters)
    {
        var pagedResult = await 
            _serviceManager.DoctorService.GetAllDoctorsAsync(parameters, false);
        
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
        
        return Ok(pagedResult.doctors);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetDoctorById(string id)
    {
        var doctor = await _serviceManager.DoctorService.GetDoctorByIdAsync(id, false);
        return Ok(doctor);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctor([FromBody] DoctorForCreationDto dto)
    {
        var doctor = await _serviceManager.DoctorService.CreateDoctorAsync(dto);
        return Ok(doctor);
    }

    [HttpDelete("id")]
    public async Task<IActionResult> CreateDoctor(string doctorId)
    {
        var result = await _serviceManager.DoctorService.DeleteDoctorByIdAsync(doctorId, true);

        return Ok(result);
    }
}