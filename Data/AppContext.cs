using ContosoUniversityApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityApi.Data;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Course> Courses { get; set; }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
    public DbSet<CourseInstructor> CoursesInstructors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().ToTable("courses")
            .HasMany(c => c.instructors)
            .WithMany(i => i.courses)
            .UsingEntity<CourseInstructor>();

        modelBuilder.Entity<Enrollment>().ToTable("enrollments");
        modelBuilder.Entity<Student>().ToTable("students");
        modelBuilder.Entity<Department>().ToTable("departments");
        modelBuilder.Entity<Instructor>().ToTable("instructors")
            .HasMany(i => i.courses)
            .WithMany(c => c.instructors)
            .UsingEntity<CourseInstructor>();
        modelBuilder.Entity<OfficeAssignment>().ToTable("offices_assignments");

        modelBuilder.Entity<CourseInstructor>(b =>
        {
            b.ToTable("courses_instructors");
            b.HasKey(e => new {CourseId = e.courseId, InstructorId = e.instructorId});
            b.HasOne(e => e.course)
                .WithMany(e => e.courseInstructors);
            b.HasOne(e => e.instructor)
                .WithMany(e => e.courseInstructors);
        });
    }
}