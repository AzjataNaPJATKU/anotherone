using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models;

[Table("Prescription")]
public class Prescription
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Precision(3)]
    public double Price { get; set; }
    public int TotalPages { get; set; }

    public ICollection<Patient> Authors { get; set; } = new HashSet<Patient>();
    
    public ICollection<Doctor> Editions { get; set; } = new HashSet<Doctor>();
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new HashSet<PrescriptionMedicament>();
}