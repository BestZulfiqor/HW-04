using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CourseController(ICourseService service)
{
    [HttpGet]
    public async Task<Response<List<Course>>> GetAllCoursesAsync()
    {
        return await service.GetAllCoursesAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Course>> GetCourseByIdAsync(int id)
    {
        return await service.GetCourseByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<Course>> AddCourseAsync(Course course)
    {
        return await service.AddCourseAsync(course);
    }

    [HttpPut]
    public async Task<Response<Course>> UpdateCourseAsync(Course course)
    {
        return await service.UpdateCourseAsync(course);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        return await service.DeleteCourseAsync(id);
    }
}