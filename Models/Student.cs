using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversityApi.Models
{
    public class Student
    {
        public int id { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string lastName { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string firstName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime enrollmentDate { get; set; }
        
        [Display(Name = "Full Name")]
        public string fullName => lastName + ", " + firstName;

        public ICollection<Enrollment> enrollments { get; set; }
    }
}