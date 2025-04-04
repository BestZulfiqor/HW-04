using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService service)
{
    [HttpGet]
    public async Task<Response<List<Student>>> GetAllStudentsAsync()
    {
        return await service.GetAllStudentsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Student>> GetStudentByIdAsync(int id)
    {
        return await service.GetStudentByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<Student>> AddStudentAsync(Student student)
    {
        return await service.AddStudentAsync(student);
    }

    [HttpPut]
    public async Task<Response<Student>> UpdateStudentAsync(Student student)
    {
        return await service.UpdateStudentAsync(student);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        return await service.DeleteStudentAsync(id);
    }
}