using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class StudentGroupController(IStudentGroupService service)
{
    [HttpGet]
    public async Task<Response<List<StudentGroup>>> GetAllStudentGroupsAsync()
    {
        return await service.GetAllStudentGroupsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int id)
    {
        return await service.GetStudentGroupByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<StudentGroup>> AddStudentGroupAsync(StudentGroup studentGroup)
    {
        return await service.AddStudentGroupAsync(studentGroup);
    }

    [HttpPut]
    public async Task<Response<StudentGroup>> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        return await service.UpdateStudentGroupAsync(studentGroup);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudentGroupAsync(int id)
    {
        return await service.DeleteStudentGroupAsync(id);
    }
}