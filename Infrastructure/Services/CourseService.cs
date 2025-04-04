using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService(DataContext context) : ICourseService
{
    public async Task<Response<List<Course>>> GetAllCoursesAsync()
    {
        var courses = await context.Courses.ToListAsync();
        return new Response<List<Course>>(courses);
    }

    public async Task<Response<Course>> GetCourseByIdAsync(int courseId)
    {
        var course = await context.Courses.FindAsync(courseId);
        
        return course == null 
            ? new Response<Course>(HttpStatusCode.BadRequest, "Course not found") 
            : new Response<Course>(course);
    }

    public async Task<Response<Course>> AddCourseAsync(Course course)
    {
        await context.Courses.AddAsync(course);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Course>(HttpStatusCode.BadRequest, "Course not created") 
            : new Response<Course>(course);
    }

    public async Task<Response<Course>> UpdateCourseAsync(Course course)
    {
        context.Courses.Update(course);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<Course>(HttpStatusCode.BadRequest, "Course not updated") 
            : new Response<Course>(course);
    }

    public async Task<Response<string>> DeleteCourseAsync(int courseId)
    {
        var course = await context.Students.FindAsync(courseId);

        if (course == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Course not found");
        }

        context.Remove(course);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "Course not deleted") 
            : new Response<string>("Course deleted successfully");
    }
}