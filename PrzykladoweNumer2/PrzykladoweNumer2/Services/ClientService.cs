using Microsoft.EntityFrameworkCore;
using PrzykladoweNumer2.Context;
using PrzykladoweNumer2.Exceptions;
using PrzykladoweNumer2.Models;
using PrzykladoweNumer2.RequestModels;

namespace PrzykladoweNumer2.Services;

public interface IClientService
{
    Task<bool> PostOrderForClient(int id,PostOrderRequestModel model);
}

public class ClientService(DatabaseContext context) : IClientService
{
    public async Task<bool> PostOrderForClient(int id, PostOrderRequestModel model)
    {
        
        using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var client = await context.Clients.FindAsync(id);
            if (client == null)
            {
                throw new NotFoundException($"Client with id:{id} not found");
            }

            var status = await context.Statuses.FirstOrDefaultAsync(s => s.Name == "utworzone");
            if (status == null)
            {
                throw new NotFoundException($"Status 'utworzone' not found");
            }
            
            foreach (var product in model.products)
            {
                var productExists = await context.Products.AnyAsync(p => p.ProductId == product.id);
                if (!productExists)
                {
                    throw new NotFoundException($"Product with id:{product.id} not found");
                }
            }

            var order = new Order
            {
                CreatedAt = model.createdAt,
                FinishedAt = model.finishedAt,
                ClientId = id,
                StatusId = status.StatusId,
                ProductOrders = model.products.Select(p => new Product_Order
                {
                    ProductId = p.id,
                    Amount = p.amount
                }).ToList()
            };

            context.Orders.Add(order);
        
            await context.SaveChangesAsync();
            
            await transaction.CommitAsync();

            return true;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}