using Przykladowe1CodeFirst.Exceptions;
using Przykladowe1CodeFirst.Services;

namespace Przykladowe1CodeFirst.Endpoints;

public static class GroupsEndpoint
{
    public static void RegisterGroupsEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("groups");

        group.MapGet("{id:int}", async (int id, IGroupsService service) =>
        {
            try
            {
                var result = await service.GetGroup(id);
                return Results.Ok(result);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.Message);
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
        });
    }
}