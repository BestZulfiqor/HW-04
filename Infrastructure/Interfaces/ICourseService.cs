using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<Response<List<Course>>> GetAllCoursesAsync();
    Task<Response<Course>> GetCourseByIdAsync(int courseId);
    Task<Response<Course>> AddCourseAsync(Course course);
    Task<Response<Course>> UpdateCourseAsync(Course course);
    Task<Response<string>> DeleteCourseAsync(int courseId);
}