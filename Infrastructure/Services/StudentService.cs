﻿using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService(DataContext context) : IStudentService
{
    public async Task<Response<List<Student>>> GetAllStudentsAsync()
    {
        var students = await context.Students.ToListAsync();
        return new Response<List<Student>>(students);
    }

    public async Task<Response<Student>> GetStudentByIdAsync(int id)
    {
        var student = await context.Students.FindAsync(id);
        
        return student == null 
            ? new Response<Student>(HttpStatusCode.BadRequest, "Student not found") 
            : new Response<Student>(student);
    }

    public async Task<Response<Student>> AddStudentAsync(Student student)
    {
        await context.Students.AddAsync(student);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Student>(HttpStatusCode.BadRequest, "Student not created") 
            : new Response<Student>(student);
    }

    public async Task<Response<Student>> UpdateStudentAsync(Student student)
    {
        context.Students.Update(student);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Student>(HttpStatusCode.BadRequest, "Student not updated") 
            : new Response<Student>(student);
    }

    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        var student = await context.Students.FindAsync(id);

        if (student == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Student not found");
        }

        context.Remove(student);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "Student not deleted") 
            : new Response<string>("Student deleted successfully");
    }
}
