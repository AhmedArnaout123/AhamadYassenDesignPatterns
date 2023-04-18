namespace DesignPatternsProject.Models;

public class Student
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public List<string> Marks { get; set; }
    
    public Student(string fullName, DateTime birthday, List<string> marks)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Birthday = birthday;
        Marks = marks;
    }
}