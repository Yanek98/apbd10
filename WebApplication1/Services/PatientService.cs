using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class PatientService: IPatientService
{
    
    private IConfiguration _configuration;
    private readonly DbContext _context;
    
    public PatientService(DbContext context)
    {
        _context = context;
    }
    
    public void setConfig(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public  async Task<Patient> GetPatient(int id)
    {
        var dbContext = new DbContext();
        var patient = await dbContext.Patients
            .Where(patient => patient.IdPatient == id)
            .Select(patient => new Patient()
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Birthdate = patient.Birthdate,
                Prescriptions = patient.Prescriptions
                    .OrderByDescending(prescription => prescription.DueDate)
                    .Select(prescription => new Prescription()
                    {
                        IdPrescription = prescription.IdPrescription,
                        Date = prescription.Date,
                        DueDate = prescription.DueDate,
                        IdDoctor = prescription.IdDoctor,
                        PrescriptionMedicaments = prescription.PrescriptionMedicaments.Select(premed => new PrescriptionMedicament()
                        {
                            IdMedicament = premed.IdMedicament,
                            Dose = premed.Dose,
                            Details = premed.Details
                        }).ToList()
                    }).ToList()
            })
            .FirstOrDefaultAsync();

        return patient;
    }
}