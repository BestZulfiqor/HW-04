using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GroupController(IGroupService service)
{
    [HttpGet]
    public async Task<Response<List<Group>>> GetAllGroupsAsync()
    {
        return await service.GetAllGroupsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Group>> GetGroupByIdAsync(int id)
    {
        return await service.GetGroupByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<Group>> AddGroupAsync(Group group)
    {
        return await service.AddGroupAsync(group);
    }

    [HttpPut]
    public async Task<Response<Group>> UpdateGroupAsync(Group group)
    {
        return await service.UpdateGroupAsync(group);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteGroupAsync(int id)
    {
        return await service.DeleteGroupAsync(id);
    }
}