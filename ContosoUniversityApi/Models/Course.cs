using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversityApi.Models;

public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "Number")]
    public int id { get; set; }

    [StringLength(50, MinimumLength = 3)] public string title { get; set; }

    [Range(0, 5)] public int credits { get; set; }

    public int departmentId { get; set; }

    public Department department { get; set; }

    public ICollection<Enrollment> enrollments { get; set; }

    public ICollection<CourseInstructor> courseInstructors { get; set; }
    public ICollection<Instructor> instructors { get; set; }
}