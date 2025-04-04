using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IStudentGroupService
{
    Task<Response<List<StudentGroup>>> GetAllStudentGroupsAsync();
    Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int studentGroupId);
    Task<Response<StudentGroup>> AddStudentGroupAsync(StudentGroup studentGroup);
    Task<Response<StudentGroup>> UpdateStudentGroupAsync(StudentGroup studentGroup);
    Task<Response<string>> DeleteStudentGroupAsync(int studentGroupId);
}