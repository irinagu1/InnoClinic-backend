using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Dtos;

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
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = await _serviceManager.DoctorService.GetAllDoctorsAsync(false);
        return Ok(doctors);
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