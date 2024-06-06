using Microsoft.EntityFrameworkCore;
using PrzykladoweNumer2.Context;
using PrzykladoweNumer2.Exceptions;
using PrzykladoweNumer2.ResponseModels;

namespace PrzykladoweNumer2.Services;

public interface IOrderService
{
    Task<IEnumerable<GetOrderResponseModel>> GetOrderByIdAsync(int id);   
}

public class OrderService(DatabaseContext context) : IOrderService
{
    public async Task<IEnumerable<GetOrderResponseModel>> GetOrderByIdAsync(int clientId)
    {
        if (clientId < 1)
        {
            throw new ArgumentException("Bad request");
        }

        var results = await context.Orders
            .Where(e => e.ClientId == clientId)
            .Select(e => new GetOrderResponseModel
            {
                OrderId = e.OrderId,
                clientsLastName = e.Client.LastName,
                createdAt = e.CreatedAt,
                finishedAt = e.FinishedAt,
                status = e.Status.Name,
                products = e.ProductOrders.Select(p => new GetOrderProduct
                {
                    productName = p.Product.Name,
                    price = p.Product.Price,
                    amount = p.Amount
                }).ToList()
            }).ToListAsync();

        if (!results.Any())
        {
            throw new NotFoundException($"No orders found for client with id:{clientId}");
        }

        return results;
    }
}