using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models;

[Table("Medicament")]
public class Medicament
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new HashSet<PrescriptionMedicament>();
}