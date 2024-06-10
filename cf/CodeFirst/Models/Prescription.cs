using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int Id { get; set; }
    public DateOnly Date { get; set; } 
    public DateOnly DueDate { get; set; }
    public int idPatient { get; set; }
    public int idDoctor { get; set; }

    public ICollection<Patient> Authors { get; set; } = new HashSet<Patient>();
    
    public ICollection<Doctor> Editions { get; set; } = new HashSet<Doctor>();
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new HashSet<PrescriptionMedicament>();
}