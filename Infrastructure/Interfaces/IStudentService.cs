using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Task<Response<List<Student>>> GetAllStudentsAsync();
    Task<Response<Student>> GetStudentByIdAsync(int studentId);
    Task<Response<Student>> AddStudentAsync(Student student);
    Task<Response<Student>> UpdateStudentAsync(Student student);
    Task<Response<string>> DeleteStudentAsync(int studentId);
}