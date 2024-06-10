using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models;

[Table("PrescriptionMedicament")]
[PrimaryKey(nameof(PrescriptionId), nameof(MedicamentId))]
public class PrescriptionMedicament
{
    public int PrescriptionId { get; set; }
    public int MedicamentId { get; set; }
    public int Dose { get; set; }
    [ForeignKey(nameof(PrescriptionId))]
    public Prescription Prescription { get; set; } = null!;
    [ForeignKey(nameof(MedicamentId))]
    public Medicament Medicament { get; set; } = null!;
}