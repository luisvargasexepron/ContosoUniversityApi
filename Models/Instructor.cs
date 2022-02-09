using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversityApi.Models;

public class Instructor
{
    public int id { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    [StringLength(50)]
    public string lastName { get; set; }

    [Required]
    [Column("FirstName")]
    [Display(Name = "First Name")]
    [StringLength(50)]
    public string firstName { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Hire Date")]
    public DateTime hireDate { get; set; }

    [Display(Name = "Full Name")]
    public string fullName => lastName + ", " + firstName;

    public ICollection<CourseInstructor> courseInstructors { get; set; }
    public ICollection<Course> courses { get; set; }
    public OfficeAssignment officeAssignment { get; set; }
}