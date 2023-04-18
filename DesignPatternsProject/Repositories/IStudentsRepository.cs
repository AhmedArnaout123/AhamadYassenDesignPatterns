using DesignPatternsProject.Models;

namespace DesignPatternsProject.Repositories;

public interface IStudentsRepository
{
    public Task AddStudent(Student student);

    public Task<bool> DeleteStudent(Guid studentId);

    public Task<List<Student>> GetAllStudents();

    public Task<Student?> GetStudentById(Guid studentId);
}