using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService(DataContext context) : IGroupService
{
    public async Task<Response<List<Group>>> GetAllGroupsAsync()
    {
        var groups = await context.Groups.ToListAsync();
        return new Response<List<Group>>(groups);
    }

    public async Task<Response<Group>> GetGroupByIdAsync(int groupId)
    {
        var group = await context.Groups.FindAsync(groupId);
        return group == null 
            ? new Response<Group>(HttpStatusCode.BadRequest, "Group not found") 
            : new Response<Group>(group);
    }

    public async Task<Response<Group>> AddGroupAsync(Group group)
    {
        await context.Groups.AddAsync(group);
        var result = await context.SaveChangesAsync();
        return result == 0 
            ? new Response<Group>(HttpStatusCode.BadRequest, "Group not created") 
            : new Response<Group>(group);
    }

    public async Task<Response<Group>> UpdateGroupAsync(Group group)
    {
        context.Groups.Update(group);
        var result = await context.SaveChangesAsync();
        return result == 0 
            ? new Response<Group>(HttpStatusCode.BadRequest, "Group not updated") 
            : new Response<Group>(group);
    }

    public async Task<Response<string>> DeleteGroupAsync(int groupId)
    {
        var group = await context.Groups.FindAsync(groupId);

        if (group == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Group not found");
        }

        context.Remove(group);
        var result = await context.SaveChangesAsync();
        
        return result == 0 
            ? new Response<string>(HttpStatusCode.BadRequest, "Group not deleted") 
            : new Response<string>("Group deleted successfully");
    }
}