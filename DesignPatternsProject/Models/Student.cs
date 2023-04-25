namespace DesignPatternsProject.Models;

public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime Birthday { get; set; }

    public string PhoneNumber { get; set; }
    
    public DateTime CreatedDate { get; private set; }

    public Student()
    {
        CreatedDate = DateTime.Now;
    }

    public Student(string firstName, string lastName, DateTime birthday, string phoneNumber)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        Birthday = birthday;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        CreatedDate = DateTime.Now;
    }
}