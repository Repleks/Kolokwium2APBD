using Microsoft.EntityFrameworkCore;
using Zadanie10.Context;
using Zadanie10.Exceptions;
using Zadanie10.ResponseModels;

namespace Zadanie10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel> GetAccount(int id);
}
public class AccountService(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountResponseModel> GetAccount(int id)
    {
        if (id < 1)
        {
            throw new ArgumentException("Your argument is invalid");
        }

        var account = await context.Accounts
            .Include(a => a.Role)
            .Include(a => a.ShoppingCarts)
            .ThenInclude(sc => sc.Product)
            .FirstOrDefaultAsync(a => a.AccountId == id);

        if (account == null)
        {
            throw new NotFoundException($"Account with id {id} not found");
        }

        var response = new GetAccountResponseModel
        {
            FirstName = account.UserFirstName,
            LastName = account.UserLastName,
            Email = account.UserEmail,
            Phone = account.UserPhone,
            Role = account.Role.RoleName,
            Cart = account.ShoppingCarts.Select(sc => new GetAccountCart
            {
                ProductId = sc.Product.ProductId,
                ProductName = sc.Product.ProductName,
                Amount = sc.Amount
            }).ToList()
        };

        return response;
    }
}