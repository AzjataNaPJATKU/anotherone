using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models;

[Table("Doctor")]
public class Doctor
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public int PublicationYear { get; set; }

    public Prescription Prescription { get; set; } = null!;
}