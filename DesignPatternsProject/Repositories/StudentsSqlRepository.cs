using DesignPatternsProject.Infrastructure;
using DesignPatternsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsProject.Repositories;

public class StudentsSqlRepository : IStudentsRepository
{
    private readonly AppDbContext _dbContext;

    public StudentsSqlRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddStudent(Student student)
    {
        await _dbContext.Students.AddAsync(student);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteStudent(Guid studentId)
    {
        var student = await _dbContext.Students.FindAsync(studentId);
        if (student is null)
            return false;
        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentById(Guid studentId)
    {
        return await _dbContext.Students.FindAsync(studentId);
    }
}