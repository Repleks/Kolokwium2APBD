using Zadanie10.Exceptions;
using Zadanie10.Services;

namespace Zadanie10.Endpoints;

public static class AccountEndpoint
{
    public static void RegisterAccountEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("account");

        group.MapGet("{id:int}", async (int id, IAccountService service) =>
        {
            try
            {
                var result = await service.GetAccount(id);
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