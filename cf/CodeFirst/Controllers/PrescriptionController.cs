using CodeFirst.DTO;
using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbservice _dbService;
    public PrescriptionController(IDbservice dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("/patient/prescription/doctor")]
    public async Task<IActionResult> addPrescriptionToPatient(NewPrescriptionDto npd)
    {
        if (!await _dbService.DoesPatientExist(npd.PatientDto.PatientId))
        {
            return NotFound("nie Istnieje");
        }
        
        
        
        
        return Ok();
    }
}