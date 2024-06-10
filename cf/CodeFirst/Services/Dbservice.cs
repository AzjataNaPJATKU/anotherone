using CodeFirst.Data;
using CodeFirst.Models;
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
    
    public int newIdforPatient()
    {
        return  _context.Patients.Select(patient => patient.Id).Max() + 1;
    }
    public int newIdforPerscription()
    {
        return _context.Prescriptions.Select(per => per.Id).Max() + 1;
    }
    public async Task AddnewPatient(Patient patient)
    {
        await _context.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task AddMedicamentPrescription(IEnumerable<PrescriptionMedicament> prescriptionMedicaments)
    {
        await _context.AddRangeAsync(prescriptionMedicaments);
        await _context.SaveChangesAsync();
    }

    public async Task AddPrescription(Prescription prescription)
    {
        await _context.AddAsync(prescription);
        await _context.SaveChangesAsync();
    }

    public async Task<Medicament?> getMedicament(int idMedicament)
    {
        return await _context.Medicaments.Where(medicament => medicament.Id == idMedicament).FirstOrDefaultAsync();
    }

    public async Task<Patient?> getPatient(int idPatient)
    {
        return await _context.Patients.Where(patient => patient.Id == idPatient).FirstOrDefaultAsync();
    }
}