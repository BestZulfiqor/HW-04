using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentGroupService(DataContext context) : IStudentGroupService
{
    public async Task<Response<List<StudentGroup>>> GetAllStudentGroupsAsync()
    {
        var studentGroups = await context.StudentGroups.ToListAsync();
        return new Response<List<StudentGroup>>(studentGroups);
    }

    public async Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int studentGroupId)
    {
        var studentGroup = await context.StudentGroups.FindAsync(studentGroupId);
        
        return studentGroup == null 
            ? new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup not found") 
            : new Response<StudentGroup>(studentGroup);
    }

    public async Task<Response<StudentGroup>> AddStudentGroupAsync(StudentGroup studentGroup)
    {
        await context.StudentGroups.AddAsync(studentGroup);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup not created") 
            : new Response<StudentGroup>(studentGroup);
    }

    public async Task<Response<StudentGroup>> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        context.StudentGroups.Update(studentGroup);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<StudentGroup>(HttpStatusCode.BadRequest, "StudentGroup not updated") 
            : new Response<StudentGroup>(studentGroup);
    }

    public async Task<Response<string>> DeleteStudentGroupAsync(int studentGroupId)
    {
        var studentGroup = await context.Students.FindAsync(studentGroupId);

        if (studentGroup == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "StudentGroup not found");
        }

        context.Remove(studentGroup);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "StudentGroup not deleted") 
            : new Response<string>("StudentGroup deleted successfully");
    }
}