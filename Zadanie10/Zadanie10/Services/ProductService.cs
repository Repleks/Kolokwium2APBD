using System.ComponentModel.DataAnnotations;
using Zadanie10.Context;
using Zadanie10.Models;
using Zadanie10.RequestModels;

namespace Zadanie10.Services;

public interface IProductService
{
    Task<bool> CreateProduct(PostProductRequestModel request);
}

public class ProductService(DatabaseContext context) : IProductService
{
    public async Task<bool> CreateProduct(PostProductRequestModel request)
    {
        var validationContext = new ValidationContext(request);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
        {
            throw new ArgumentException("Invalid request model");
        }
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var product = new Product
            {
                ProductName = request.productName,
                Weight = request.productWeight,
                Width = request.productWidth,
                Height = request.productHeight,
                Depth = request.productDepth
            };
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            foreach (var categoryId in request.categories)
            {
                var category = await context.Categories.FindAsync(categoryId);
                if (category == null)
                {
                    throw new ArgumentException("Category does not exist");
                }
                var productCategory = new ProductCategory
                {
                    ProductId = product.ProductId,
                    CategoryId = categoryId
                };
                await context.ProductCategories.AddAsync(productCategory);
            }
            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            return false;
        }
        
    }
}