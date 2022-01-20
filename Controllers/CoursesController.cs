using ContosoUniversityApi.Data;
using ContosoUniversityApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : AODataControllerBase<Course>
{
    public CoursesController(AppContext context)
        : base(context, "Course", e => e.Id) { }
}