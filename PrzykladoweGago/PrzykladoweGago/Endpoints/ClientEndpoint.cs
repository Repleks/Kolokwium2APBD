using PrzykladoweGago.Exceptions;
using PrzykladoweGago.Services;

namespace PrzykladoweGago.Endpoints;

public static class ClientEndpoint
{
    public static void RegisterClientEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("client");

        group.MapGet("{id:int}", async (int id, IClientService service) =>
        {
            try
            {
                var result = await service.GetReservationForClientAsync(id);
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