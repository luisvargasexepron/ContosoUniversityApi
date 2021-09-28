using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.OData.Query;

namespace ContosoUniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        [CustomEnableQuery]
        public IQueryable<Course> GetCourses()
        {
            return _context.Courses;
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        [CustomEnableQueryOne]
        public ActionResult<Course> GetCourse(int id)
        {
            var course = _context.Courses.Where(e => e.Id == id).AsNoTracking();

            if (!course.Any())
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [CustomEnableQueryOne]
        public ActionResult<Course> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
                return BadRequest("The Id specified in path is different from the body Id");
            }
            if (!CourseExists(id))
            {
                return NotFound($"Entity with Id '{id}' not found");
            }

            _context.Entry(course).State = EntityState.Modified;

            _context.SaveChanges();

            return GetCourse(id);
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [CustomEnableQueryOne]
        public ActionResult<Course> PostCourse(Course course)
        {
            if (course.Id != 0 && CourseExists(course.Id))
            {
                return Conflict("Course with specified Id already Exists");
            }

            _context.Courses.Add(course);
            _context.SaveChanges();

            return GetCourse(course.Id);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }
    }
}
