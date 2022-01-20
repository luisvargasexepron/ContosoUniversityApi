using ContosoUniversityApi.Data;
using ContosoUniversityApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : AODataControllerBase<Department>
{
    public DepartmentsController(AppContext context)
        : base(context, "Department", e => e.Id) { }
}