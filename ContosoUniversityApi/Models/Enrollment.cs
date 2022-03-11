using System.ComponentModel.DataAnnotations;

namespace ContosoUniversityApi.Models;

public enum Grade
{
    A, B, C, D, F
}
    
public class Enrollment
{
    public int id { get; set; }
    public int courseId { get; set; }
    public int studentId { get; set; }
        
    [DisplayFormat(NullDisplayText = "No grade")]
    public Grade? grade { get; set; }

    public Course course { get; set; }
    public Student student { get; set; }
}