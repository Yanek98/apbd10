using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiController : ControllerBase
{

    private readonly IPatientService _patientService;
    private readonly IPrescriptionService _prescriptionService;
    private readonly IConfiguration _configuration;


    public ApiController(IPatientService patientService, IPrescriptionService prescriptionService, IConfiguration configuration)
    {
        _patientService = patientService;
        _prescriptionService = prescriptionService;
        _configuration = configuration;
        _patientService.setConfig(_configuration);
        _prescriptionService.setConfig(_configuration);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patient = _patientService.GetPatient(id);
        
        if (patient == null)
        {
            return NotFound("Nie znaleziono pacjenta!");
        }

        return Ok(patient);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescDTO prescDto)
    {

        var result = _prescriptionService.AddPrescription(prescDto);
        return Ok(result);
    }
    //KOMENDY NA MIGRACJE
    //dotnet ef migrations add InitialCreate
    //dotnet ef database update
}