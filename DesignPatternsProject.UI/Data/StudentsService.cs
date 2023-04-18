﻿using DesignPatternsProject.Models;

namespace DesignPatternsProject.UI.Data;

public class StudentsService
{
    public async Task<List<Student>> GetStudentsList()
    {
        var httpClient = new HttpClient();
        await Task.CompletedTask;
        return GetInMemoryStudents();
    }

    private List<Student> GetInMemoryStudents()
    {
        var list = new List<Student>();
        for (var i = 0; i < 3; i++)
        {
            var birthDay = DateTime.Now.AddYears(-(new Random().Next(20, 24)));
            var firstName = $"firstName {i}";
            var lastName = $"lastName {i}";
            var phoneNumber = $"Phone Number {i}";
            list.Add(new Student(firstName, lastName, birthDay, phoneNumber));
        }

        return list;
    }
}