using DesignPatternsProject.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DesignPatternsProject.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IMongoCollection<Student> _collection;

    public StudentsController(IMongoDatabase database)
    {
        _collection = database.GetCollection<Student>("Students");
    }
    
    [HttpPost]
    public async Task<ActionResult> AddStudent([FromBody] Student student)
    {
        student.Id = Guid.NewGuid();
        await _collection.InsertOneAsync(student);
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteStudent(Guid id)
    {
        var result = await _collection.DeleteOneAsync(s => s.Id == id);
        if (result.DeletedCount == 0)
            return NotFound();
        return Ok();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetAllStudents()
    {
        var list = await (await _collection.FindAsync(new BsonDocument())).ToListAsync();
        return Ok(list);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<List<Student>>> GetStudentById(Guid id)
    {
        var student = await (await _collection.FindAsync(student => student.Id == id)).FirstOrDefaultAsync();
        if (student is null)
            return NotFound();
        
        return Ok(student);
    }
}