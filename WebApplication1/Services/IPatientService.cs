using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IPatientService
{
    public Task<Patient> GetPatient(int id);
    public void setConfig(IConfiguration configuration);
}