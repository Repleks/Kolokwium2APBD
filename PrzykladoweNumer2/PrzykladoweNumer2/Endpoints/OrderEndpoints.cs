using PrzykladoweNumer2.Exceptions;
using PrzykladoweNumer2.Services;

namespace PrzykladoweNumer2.Endpoints;

public static class OrderEndpoints
{
    public static void RegisterOrderEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("orders");
        
        group.MapGet("{id:int}", async (int id, IOrderService service) =>
        {
            try
            {
                return Results.Ok(await service.GetOrderByIdAsync(id));
            }
            catch (NotFoundException e)
            {
                return Results.NotFound(e.Message);
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }
}