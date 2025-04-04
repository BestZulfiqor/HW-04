using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IGroupService
{
    Task<Response<List<Group>>> GetAllGroupsAsync();
    Task<Response<Group>> GetGroupByIdAsync(int groupId);
    Task<Response<Group>> AddGroupAsync(Group group);
    Task<Response<Group>> UpdateGroupAsync(Group group);
    Task<Response<string>> DeleteGroupAsync(int groupId);
}