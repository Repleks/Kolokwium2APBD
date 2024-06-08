using Microsoft.EntityFrameworkCore;
using PrzykladoweGago.Contexts;
using PrzykladoweGago.Exceptions;
using PrzykladoweGago.ResponseModels;

namespace PrzykladoweGago.Services;

public interface IClientService
{
    Task<GetReservationForClientResponseModel> GetReservationForClientAsync(int idClient);
}
public class ClientService(DatabaseContext context) : IClientService
{
    public async Task<GetReservationForClientResponseModel> GetReservationForClientAsync(int idClient)
    {
        if( idClient < 1 )
        {
            throw new ArgumentException("Your argument is invalid");
        }
        
        var client = await context.Clients
            .Include(c => c.Reservations)
            .ThenInclude(r => r.BoatStandard)
            .FirstOrDefaultAsync(c => c.IdClient == idClient);

        if (client == null)
        {
            throw new NotFoundException($"Client with id {idClient} not found");
        }

        var response = new GetReservationForClientResponseModel
        {
            Name = client.Name,
            LastName = client.LastName,
            Birthday = client.Birthday,
            Pesel = client.Pesel,
            Email = client.Email,
            Reservations = client.Reservations.Select(r => new ReservationResponseModel
            {
                IdReservation = r.IdReservation,
                DateFrom = r.DateFrom,
                DateTo = r.DateTo,
                IdBoatStandard = r.IdBoatStandard,
                Capacity = r.Capacity,
                NumOfBoats = r.NumOfBoats,
                Fulfilled = r.Fulfilled,
                Price = r.Price,
                CancelReason = r.CancelReason
            }).ToList()
        };
        response.Reservations = response.Reservations.OrderByDescending(r => r.DateTo).ToList();

        return response;
    }
}