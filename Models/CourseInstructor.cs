using ContosoUniversityApi.Models;

namespace ContosoUniversityApi.Models
{
    public class CourseInstructor
    {
        public int instructorId { get; set; }
        public int courseId { get; set; }
        public Instructor instructor { get; set; }
        public Course course { get; set; }
    }
}