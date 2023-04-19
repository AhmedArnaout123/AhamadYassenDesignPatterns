using DesignPatternsProject.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DesignPatternsProject.Repositories;

public class StudentsMongoDbRepository : IStudentsRepository
{
    private readonly IMongoCollection<Student> _collection;

    public StudentsMongoDbRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Student>("Students");
    }
    
    public async Task AddStudent(Student student)
    {
        await _collection.InsertOneAsync(student);
    }

    public async Task<bool> DeleteStudent(Guid studentId)
    {
        var result = await _collection.DeleteOneAsync(s => s.Id == studentId);
        return result.DeletedCount != 0;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await (await _collection.FindAsync(new BsonDocument())).ToListAsync();
    }

    public async Task<Student?> GetStudentById(Guid studentId)
    {
        return await (await _collection.FindAsync(student => student.Id == studentId)).FirstOrDefaultAsync();
    }
    
}