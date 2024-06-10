using System.Transactions;
using CodeFirst.DTO;
using CodeFirst.Models;
using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly IDbservice _dbService;
    public PrescriptionController(IDbservice dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("/patient/prescription/doctor")]
    public async Task<IActionResult> addPrescriptionToPatient(NewPrescriptionDto npd)
    {
        if (npd.DueDate < npd.date)
        {
            return Problem("problem");
        }
        
        var medicaments = new List<MedicamentDto>();
        foreach (var newMedicament in npd.Medicaments)
        {
            if (await _dbService.DoesMedicamentExist(newMedicament.MedicamentId))
            {
                return NotFound("WHERE?");
            }

            if (medicaments.Count >= 10)
            {
                return Problem("too much");
            }
            
            medicaments.Add(newMedicament);
        }
        var patient = new Patient();
        if (!await _dbService.DoesPatientExist(npd.PatientDto.PatientId))
        {
                    
                    patient.Id = _dbService.newIdforPatient();
                    patient.FirstName = npd.PatientDto.Firstname;
                    patient.LastName = npd.PatientDto.Lastname;
                    patient.BirthDate = npd.PatientDto.BirthDate;
                    await _dbService.AddnewPatient(patient);
        }
        else
        {
            patient = await _dbService.getPatient(npd.PatientDto.PatientId);
        }

        var pres = new Prescription();
        pres.Id = _dbService.newIdforPerscription();
        pres.Date = npd.date;
        pres.DueDate = npd.DueDate;
        pres.idPatient = patient.Id;
        pres.idDoctor = npd.DoctorDto.DoctortId;
        
        var permed = new List<PrescriptionMedicament>();
        int i = 1;
        foreach (var newMedicament in medicaments)
        {
            var temp = new PrescriptionMedicament();
            temp.PrescriptionId = i++;
            temp.MedicamentId = newMedicament.MedicamentId;
            temp.Dose = newMedicament.Dose;
            temp.details = newMedicament.Description;
            
            permed.Add(temp);
        }
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _dbService.AddPrescription(pres);
            await _dbService.AddMedicamentPrescription(permed);
    
            scope.Complete();
        }
        
        return Created();
    }
}