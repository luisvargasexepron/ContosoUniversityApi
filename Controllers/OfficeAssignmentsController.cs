using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversityApi.Data;
using ContosoUniversityApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfficeAssignmentsController : AODataControllerBase<OfficeAssignment>
{
    public OfficeAssignmentsController(AppContext context)
        : base(context, "OfficeAssignment", e => e.InstructorId) {}
}