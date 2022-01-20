using ContosoUniversityApi.Data;
using ContosoUniversityApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentsController : AODataControllerBase<Enrollment>
{
    public EnrollmentsController(AppContext context)
        : base(context, "Enrollment", e => e.Id) { }
}