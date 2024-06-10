using CodeFirst.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CodeFirst.Services;

public class Dbservice : IDbservice
{
    private readonly ApplicationContext _context;
    public Dbservice(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<bool> DoesPatientExist(int idPatient)
    {
        return await _context.Patients.Where(patient => patient.Id == idPatient).AnyAsync();
    }

    public async Task<bool> DoesMedicamentExist(int idMedicament)
    {
        return await _context.Medicaments.Where(medicament => medicament.Id == idMedicament).AnyAsync();
    }

    public async Task<bool> DoesPrescriptionHas10(int idPrescription)
    {
        return _context.PrescriptionMedicaments
            .Where(pm => pm.PrescriptionId == idPrescription)
            .GroupBy(pm => pm.Prescription)
            .Select(pm => pm.Count()).First() < 10;
    }
}