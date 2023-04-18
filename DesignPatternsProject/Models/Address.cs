namespace DesignPatternsProject.Models;

public class Address
{
    public Guid Id  { get; set; }
    
    public Guid StudentId { get; set; }
    
    public string Country { get; set; }
    
    public string City { get; set; }
    
    public string Street { get; set; }
    
    public Address(Guid studentId, string country, string city, string street)
    {
        Id = Guid.NewGuid();
        StudentId = studentId;
        Country = country;
        City = city;
        Street = street;
    }
}