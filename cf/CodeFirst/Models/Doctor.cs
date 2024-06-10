using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models;

[Table("Doctor")]
public class Doctor
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; }

    public Prescription Prescription { get; set; } = null!;
}