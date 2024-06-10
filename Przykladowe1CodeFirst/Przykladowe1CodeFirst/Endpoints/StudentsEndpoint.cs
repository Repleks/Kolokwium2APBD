using Przykladowe1CodeFirst.Exceptions;
using Przykladowe1CodeFirst.Services;

namespace Przykladowe1CodeFirst.Endpoints;

public static class StudentsEndpoint
{
    public static void RegisterStudentsEndpoint(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("students");
        
        group.MapDelete("{id:int}", async (int id, IStudentsService service) =>
        {
            try
            {
                var result = await service.DeleteStudent(id);
                if(result)
                    return Results.NoContent();
                return Results.Problem("Unknown error occured, please try again later.");
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