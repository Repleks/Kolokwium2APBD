using Microsoft.AspNetCore.Mvc;
using Zadanie10.Exceptions;
using Zadanie10.RequestModels;
using Zadanie10.Services;

namespace Zadanie10.Endpoints;

public static class ProductEndpoint
{
    public static void RegisterProductEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("product");

        group.MapPost("", async (PostProductRequestModel model, IProductService service) =>
        {
            try
            {
                var result = await service.CreateProduct(model);
                if(result)
                    return Results.Created();
                return Results.Problem("Unknown error occured, please try again later.");
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }
}