namespace CodeFirst.DTO;

public class NewPrescriptionDto
{
    public int PrescriptionId;
    public DateOnly date;
    public DateOnly DueDate;
    public PatientDto PatientDto;
    public DoctorDto DoctorDto;
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