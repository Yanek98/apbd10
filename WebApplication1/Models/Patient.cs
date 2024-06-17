namespace WebApplication1.Models;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly Birthdate { get; set; }
    public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}