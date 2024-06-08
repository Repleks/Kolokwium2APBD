using PrzykladoweGago.Exceptions;
using PrzykladoweGago.RequestModels;
using PrzykladoweGago.Services;

namespace PrzykladoweGago.Endpoints;

public static class ReservationEndpoint
{
    public static void RegisterReservationEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("reservation");

        group.MapPost("", async (PostReservationRequestModel model, IReservationService service) =>
        {
            try
            {
                var result = await service.AddReservationAsync(model);
                if(result)
                    return Results.NoContent();
                return Results.Problem("Unable to add reservation, try again later.");
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