namespace CodeFirst.DTO;

public class NewPrescriptionDto
{
    public DateOnly date;
    public DateOnly DueDate;
    public PatientDto PatientDto;
    public DoctorDto DoctorDto;
    public ICollection<MedicamentDto> Medicaments = new List<MedicamentDto>();
}
public class PatientDto
{
    public int PatientId;
    public string Firstname;
    public string Lastname;
    public DateOnly BirthDate;
}
public class DoctorDto
{
    public int DoctortId;
    public string Firstname;
}

public class MedicamentDto
{
    public int MedicamentId;
    public int Dose;
    public string? Description;
}