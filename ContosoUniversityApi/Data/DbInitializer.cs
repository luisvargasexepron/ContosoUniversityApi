using System;
using System.Linq;
using ContosoUniversityApi.Models;

namespace ContosoUniversityApi.Data;

public static class DbInitializer
{
    public static void Initialize(AppContext context)
    {
        context.Database.EnsureCreated();

        // Look for any students.
        if (context.Students.Any())
        {
            return; // DB has been seeded
        }

        var students = new[]
        {
            new Student
            {
                firstName = "Carson",
                lastName = "Alexander",
                enrollmentDate = DateTime.Parse("2016-09-01")
            },
            new Student
            {
                firstName = "Meredith",
                lastName = "Alonso",
                enrollmentDate = DateTime.Parse("2018-09-01")
            },
            new Student
            {
                firstName = "Arturo",
                lastName = "Anand",
                enrollmentDate = DateTime.Parse("2019-09-01")
            },
            new Student
            {
                firstName = "Gytis",
                lastName = "Barzdukas",
                enrollmentDate = DateTime.Parse("2018-09-01")
            },
            new Student
            {
                firstName = "Yan",
                lastName = "Li",
                enrollmentDate = DateTime.Parse("2018-09-01")
            },
            new Student
            {
                firstName = "Peggy",
                lastName = "Justice",
                enrollmentDate = DateTime.Parse("2017-09-01")
            },
            new Student
            {
                firstName = "Laura",
                lastName = "Norman",
                enrollmentDate = DateTime.Parse("2019-09-01")
            },
            new Student
            {
                firstName = "Nino",
                lastName = "Olivetto",
                enrollmentDate = DateTime.Parse("2011-09-01")
            }
        };

        context.Students.AddRange(students);
        context.SaveChanges();

        var instructors = new[]
        {
            new Instructor
            {
                firstName = "Kim",
                lastName = "Abercrombie",
                hireDate = DateTime.Parse("1995-03-11")
            },
            new Instructor
            {
                firstName = "Fadi",
                lastName = "Fakhouri",
                hireDate = DateTime.Parse("2002-07-06")
            },
            new Instructor
            {
                firstName = "Roger",
                lastName = "Harui",
                hireDate = DateTime.Parse("1998-07-01")
            },
            new Instructor
            {
                firstName = "Candace",
                lastName = "Kapoor",
                hireDate = DateTime.Parse("2001-01-15")
            },
            new Instructor
            {
                firstName = "Roger",
                lastName = "Zheng",
                hireDate = DateTime.Parse("2004-02-12")
            }
        };

        context.Instructors.AddRange(instructors);
        context.SaveChanges();

        var departments = new[]
        {
            new Department
            {
                name = "English", budget = 350000,
                startDate = DateTime.Parse("2007-09-01"),
                administratorId = instructors.Single(i => i.lastName == "Abercrombie").id
            },
            new Department
            {
                name = "Mathematics", budget = 100000,
                startDate = DateTime.Parse("2007-09-01"),
                administratorId = instructors.Single(i => i.lastName == "Fakhouri").id
            },
            new Department
            {
                name = "Engineering", budget = 350000,
                startDate = DateTime.Parse("2007-09-01"),
                administratorId = instructors.Single(i => i.lastName == "Harui").id
            },
            new Department
            {
                name = "Economics", budget = 100000,
                startDate = DateTime.Parse("2007-09-01"),
                administratorId = instructors.Single(i => i.lastName == "Kapoor").id
            }
        };

        context.Departments.AddRange(departments);
        context.SaveChanges();

        var courses = new[]
        {
            new Course
            {
                id = 1050, title = "Chemistry", credits = 3,
                departmentId = departments.Single(s => s.name == "Engineering").id
            },
            new Course
            {
                id = 4022, title = "Microeconomics", credits = 3,
                departmentId = departments.Single(s => s.name == "Economics").id
            },
            new Course
            {
                id = 4041, title = "Macroeconomics", credits = 3,
                departmentId = departments.Single(s => s.name == "Economics").id
            },
            new Course
            {
                id = 1045, title = "Calculus", credits = 4,
                departmentId = departments.Single(s => s.name == "Mathematics").id
            },
            new Course
            {
                id = 3141, title = "Trigonometry", credits = 4,
                departmentId = departments.Single(s => s.name == "Mathematics").id
            },
            new Course
            {
                id = 2021, title = "Composition", credits = 3,
                departmentId = departments.Single(s => s.name == "English").id
            },
            new Course
            {
                id = 2042, title = "Literature", credits = 4,
                departmentId = departments.Single(s => s.name == "English").id
            },
        };

        context.Courses.AddRange(courses);
        context.SaveChanges();

        var officeAssignments = new[]
        {
            new OfficeAssignment
            {
                InstructorId = instructors.Single(i => i.lastName == "Fakhouri").id,
                location = "Smith 17"
            },
            new OfficeAssignment
            {
                InstructorId = instructors.Single(i => i.lastName == "Harui").id,
                location = "Gowan 27"
            },
            new OfficeAssignment
            {
                InstructorId = instructors.Single(i => i.lastName == "Kapoor").id,
                location = "Thompson 304"
            },
        };

        context.OfficeAssignments.AddRange(officeAssignments);
        context.SaveChanges();

        var courseInstructors = new[]
        {
            new CourseInstructor
            {
                courseId = courses.Single(c => c.title == "Chemistry").id,
                instructorId = instructors.Single(i => i.lastName == "Kapoor").id
            },
            new CourseInstructor
            {
                courseId = courses.Single(c => c.title == "Chemistry").id,
                instructorId = instructors.Single(i => i.lastName == "Harui").id
            },
            new CourseInstructor
            {
                courseId = courses.Single(c => c.title == "Microeconomics").id,
                instructorId = instructors.Single(i => i.lastName == "Zheng").id
            },
            new CourseInstructor
            {
                courseId = courses.Single(c => c.title == "Macroeconomics").id,
                instructorId = instructors.Single(i => i.lastName == "Zheng").id
            },
            new CourseInstructor
            {
                courseId = courses.Single(c => c.title == "Calculus").id,
                instructorId = instructors.Single(i => i.lastName == "Fakhouri").id
            },
            new CourseInstructor
            {
                courseId = courses.Single(c => c.title == "Trigonometry").id,
                instructorId = instructors.Single(i => i.lastName == "Harui").id
            },
            new CourseInstructor
            {
                courseId = courses.Single(c => c.title == "Composition").id,
                instructorId = instructors.Single(i => i.lastName == "Abercrombie").id
            },
            new CourseInstructor
            {
                courseId = courses.Single(c => c.title == "Literature").id,
                instructorId = instructors.Single(i => i.lastName == "Abercrombie").id
            },
        };

        context.CoursesInstructors.AddRange(courseInstructors);
        context.SaveChanges();

        var enrollments = new[]
        {
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Alexander").id,
                courseId = courses.Single(c => c.title == "Chemistry").id,
                grade = Grade.A
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Alexander").id,
                courseId = courses.Single(c => c.title == "Microeconomics").id,
                grade = Grade.C
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Alexander").id,
                courseId = courses.Single(c => c.title == "Macroeconomics").id,
                grade = Grade.B
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Alonso").id,
                courseId = courses.Single(c => c.title == "Calculus").id,
                grade = Grade.B
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Alonso").id,
                courseId = courses.Single(c => c.title == "Trigonometry").id,
                grade = Grade.B
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Alonso").id,
                courseId = courses.Single(c => c.title == "Composition").id,
                grade = Grade.B
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Anand").id,
                courseId = courses.Single(c => c.title == "Chemistry").id
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Anand").id,
                courseId = courses.Single(c => c.title == "Microeconomics").id,
                grade = Grade.B
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Barzdukas").id,
                courseId = courses.Single(c => c.title == "Chemistry").id,
                grade = Grade.B
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Li").id,
                courseId = courses.Single(c => c.title == "Composition").id,
                grade = Grade.B
            },
            new Enrollment
            {
                studentId = students.Single(s => s.lastName == "Justice").id,
                courseId = courses.Single(c => c.title == "Literature").id,
                grade = Grade.B
            }
        };

        foreach (Enrollment e in enrollments)
        {
            var enrollmentInDataBase = context.Enrollments
                .SingleOrDefault(s => s.student.id == e.id && s.course.id == e.id);
            if (enrollmentInDataBase == null)
            {
                context.Enrollments.Add(e);
            }
        }

        context.SaveChanges();
    }
}