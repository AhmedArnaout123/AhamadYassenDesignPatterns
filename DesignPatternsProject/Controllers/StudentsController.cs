using DesignPatternsProject.Infrastructure;
using DesignPatternsProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        student.Id = Guid.NewGuid();
        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteStudent(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id);
        if (student is null)
            return NotFound();
        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAll()
    {
        var list = await _dbContext.Students.ToListAsync();
        return Ok(list);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<Student>>> GetById(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id);
        if (student is null)
            return NotFound();
        
        return Ok(student);
    }
}