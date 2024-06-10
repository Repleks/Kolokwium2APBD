using Microsoft.EntityFrameworkCore;
using Przykladowe1CodeFirst.Context;
using Przykladowe1CodeFirst.Exceptions;
using Przykladowe1CodeFirst.ResponseModels;

namespace Przykladowe1CodeFirst.Services;

public interface IGroupsService
{
    Task<GetGroupResponseModel> GetGroup(int id);   
}

public class GroupsService(DatabaseContext context) : IGroupsService
{
    public async Task<GetGroupResponseModel> GetGroup(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Your argument is invalid");
        }
        var group = await context.Groups
            .Include(g => g.GroupAssignments)
            .FirstOrDefaultAsync(g => g.GroupId == id);

        if (group == null)
        {
            throw new NotFoundException($"Group with id {id} not found");
        }

        var response = new GetGroupResponseModel
        {
            GroupId = group.GroupId,
            Name = group.Name,
            StudentIds = group.GroupAssignments.Select(ga => ga.StudentId)
        };

        return response;
    }
}