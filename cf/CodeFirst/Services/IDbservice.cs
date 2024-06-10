using CodeFirst.Models;

namespace CodeFirst.Services;

public interface IDbservice
{
    Task<bool> DoesPatientExist(int idPatient);
    Task<bool> DoesMedicamentExist(int idMedicament);
    int newIdforPatient();
    int newIdforPerscription();
    Task<Medicament?> getMedicament(int idMedicament);
    Task<Patient?> getPatient(int idPatient);
    Task AddnewPatient(Patient patient);
    Task AddMedicamentPrescription(IEnumerable<PrescriptionMedicament> prescriptionMedicaments);
    Task AddPrescription(Prescription prescription);

}