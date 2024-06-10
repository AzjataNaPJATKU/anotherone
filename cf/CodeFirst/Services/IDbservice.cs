namespace CodeFirst.Services;

public interface IDbservice
{
    Task<bool> DoesPatientExist(int idPatient);
    Task<bool> DoesMedicamentExist(int idMedicament);
    Task<bool> DoesPrescriptionHas10(int idPrescription);
}