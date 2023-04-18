namespace DesignPatternsProject.Models;

public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthday { get; set; }

    public string PhoneNumber { get; set; }

    public Student()
    {
        
    }

    public Student(string firstName, string lastName, DateTime birthday, string phoneNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        Birthday = birthday;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }
}