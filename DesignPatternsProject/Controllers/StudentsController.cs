using DesignPatternsProject.Infrastructure;
using DesignPatternsProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsProject.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public StudentsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpPost]
    public async Task<ActionResult> AddStudent([FromBody] Student student)
    {
        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
}