using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityApi.Models;

public class OfficeAssignment
{
    [Key] public int InstructorId { get; set; }

    [StringLength(50)]
    [Display(Name = "Office Location")]
    public string location { get; set; }

    public Instructor instructor { get; set; }
}