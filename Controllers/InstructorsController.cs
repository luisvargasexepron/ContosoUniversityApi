using ContosoUniversityApi.Data;
using ContosoUniversityApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController : AODataControllerBase<Instructor>
{
    public InstructorsController(AppContext context)
        : base(context, "Instructor", e => e.id) { }
}