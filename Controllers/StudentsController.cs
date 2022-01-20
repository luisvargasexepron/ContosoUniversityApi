using ContosoUniversityApi.Data;
using ContosoUniversityApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : AODataControllerBase<Student>
{
    public StudentsController(AppContext context)
        : base(context, "Student", e => e.Id) { }
}