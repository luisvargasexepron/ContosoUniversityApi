using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeAssignmentsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public OfficeAssignmentsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: api/OfficeAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeAssignment>>> GetOfficeAssignments()
        {
            return await _context.OfficeAssignments.ToListAsync();
        }

        // GET: api/OfficeAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeAssignment>> GetOfficeAssignment(int id)
        {
            var officeAssignment = await _context.OfficeAssignments.FindAsync(id);

            if (officeAssignment == null)
            {
                return NotFound();
            }

            return officeAssignment;
        }

        // PUT: api/OfficeAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOfficeAssignment(int id, OfficeAssignment officeAssignment)
        {
            if (id != officeAssignment.InstructorId)
            {
                return BadRequest();
            }

            _context.Entry(officeAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeAssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/OfficeAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OfficeAssignment>> PostOfficeAssignment(OfficeAssignment officeAssignment)
        {
            _context.OfficeAssignments.Add(officeAssignment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OfficeAssignmentExists(officeAssignment.InstructorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOfficeAssignment", new { id = officeAssignment.InstructorId }, officeAssignment);
        }

        // DELETE: api/OfficeAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOfficeAssignment(int id)
        {
            var officeAssignment = await _context.OfficeAssignments.FindAsync(id);
            if (officeAssignment == null)
            {
                return NotFound();
            }

            _context.OfficeAssignments.Remove(officeAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeAssignmentExists(int id)
        {
            return _context.OfficeAssignments.Any(e => e.InstructorId == id);
        }
    }
}
