using DesignPatternsProject.Models;
using DesignPatternsProject.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatternsProject.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentsRepository _studentsRepository;

    public StudentsController(IStudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }
    
    [HttpPost]
    public async Task<ActionResult> AddStudent([FromBody] Student student)
    {
        await _studentsRepository.AddStudent(student);
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteStudent(Guid id)
    {
        return (await _studentsRepository.DeleteStudent(id)) 
            ? Ok()
            : NotFound();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAllStudents()
    {
        return Ok(await _studentsRepository.GetAllStudents());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<Student>>> GetStudentById(Guid id)
    {
        return (await _studentsRepository.GetStudentById(id)) is not null
            ? Ok()
            : NotFound();
    }
}