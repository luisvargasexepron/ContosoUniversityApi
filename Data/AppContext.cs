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
            .HasMany(c => c.Instructors)
            .WithMany(i => i.Courses)
            .UsingEntity<CourseInstructor>(
                e => e
                    .HasOne(ci => ci.Instructor)
                    .WithMany(i => i.CourseInstructors)
                    .HasForeignKey(ci => ci.InstructorId),
                e => e
                    .HasOne(ci => ci.Course)
                    .WithMany(c => c.CourseInstructors)
                    .HasForeignKey(ci => ci.CourseId),
                e => e.HasKey(ci => new { ci.CourseId, ci.InstructorId }));

        modelBuilder.Entity<Enrollment>().ToTable("enrollments");
        modelBuilder.Entity<Student>().ToTable("students");
        modelBuilder.Entity<Department>().ToTable("departments");
        modelBuilder.Entity<Instructor>().ToTable("instructors")
            .HasMany(i => i.Courses)
            .WithMany(c => c.Instructors)
            .UsingEntity(e => e.ToTable("courses_instructors"));
        modelBuilder.Entity<OfficeAssignment>().ToTable("offices_assignments");
    }
}