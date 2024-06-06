using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PrzykladoweNumer2.Exceptions;
using PrzykladoweNumer2.RequestModels;
using PrzykladoweNumer2.Services;

namespace PrzykladoweNumer2.Endpoints;

public static class ClientEndpoints
{
    public static void RegisterClientEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("clients");
        
        group.MapPost("{id:int}", async (int id, [FromBody]PostOrderRequestModel model, IClientService service) =>
        {
            try
            {
                bool result = await service.PostOrderForClient(id, model);
                if (result)
                    return Results.NoContent();
                return Results.Problem("Something went wrong. please try again later.");
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