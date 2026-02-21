using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

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
    public IActionResult GetAllDoctors()
    {
        var doctors = _serviceManager.DoctorService.GetAllDoctors(false);
        return Ok(doctors);
    }
}