using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversityApi.Models;

namespace ContosoUniversityApi.Models
{
    public class Department
    {
        public int id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string name { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

        public int? administratorId { get; set; }
        public Instructor administrator { get; set; }

        public ICollection<Course> courses { get; set; }
    }
}