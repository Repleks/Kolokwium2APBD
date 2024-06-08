using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using PrzykladoweGago.Contexts;
using PrzykladoweGago.Exceptions;
using PrzykladoweGago.Models;
using PrzykladoweGago.RequestModels;

namespace PrzykladoweGago.Services;

public interface IReservationService
{
    Task<bool> AddReservationAsync(PostReservationRequestModel postReservationRequestModel);
}
public class ReservationService(DatabaseContext context) : IReservationService
{
    public async Task<bool> AddReservationAsync(PostReservationRequestModel postReservationRequestModel)
    {
        
        var validationContext = new ValidationContext(postReservationRequestModel);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(postReservationRequestModel, validationContext, validationResults, true))
        {
            throw new ArgumentException(validationResults.First().ErrorMessage);
        }
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            var client =
                await context.Clients.FirstOrDefaultAsync(c => c.IdClient == postReservationRequestModel.IdClient);
            if (client == null)
            {
                throw new NotFoundException($"Client with id {postReservationRequestModel.IdClient} not found");
            }

            var boatStandard = await context.BoatStandards.FirstOrDefaultAsync(bs =>
                bs.IdBoatStandard == postReservationRequestModel.IdBoatStandard);
            if (boatStandard == null)
            {
                throw new NotFoundException(
                    $"Boat standard with id {postReservationRequestModel.IdBoatStandard} not found");
            }

            var reservations = await context.Reservations
                .Where(r => r.IdBoatStandard == postReservationRequestModel.IdBoatStandard)
                .Where(r => r.DateFrom <= postReservationRequestModel.DateTo &&
                            r.DateTo >= postReservationRequestModel.DateFrom)
                .ToListAsync();
            var reservedBoats = reservations.Sum(r => r.NumOfBoats);
            var availableBoats = await context.Sailboats
                .Where(b => b.IdBoatStandard == postReservationRequestModel.IdBoatStandard)
                .CountAsync();
            if (reservedBoats + postReservationRequestModel.NumOfBoats > availableBoats)
            {
                throw new ArgumentException("Not enough boats available");
            }

            var clientReservations = await context.Reservations
                .Where(r => r.IdClient == postReservationRequestModel.IdClient)
                .Where(r => r.DateFrom <= postReservationRequestModel.DateTo &&
                            r.DateTo >= postReservationRequestModel.DateFrom)
                .ToListAsync();
            if (clientReservations.Any())
            {
                throw new ArgumentException("Client has already reservation in this time");
            }

            var days = (postReservationRequestModel.DateTo - postReservationRequestModel.DateFrom).Days;
            var reservationIds = reservations.Select(r => r.IdReservation).ToList();
            var price = await context.Sailboats
                .Where(s => s.IdBoatStandard == postReservationRequestModel.IdBoatStandard)
                .Where(s => !context.SailboatReservations.Any(sr => sr.IdSailboat == s.IdSailboat && reservationIds.Contains(sr.IdReservation)))
                .Select(s => s.Price * days)
                .FirstOrDefaultAsync();
            if (price == 0)
            {
                throw new ArgumentException("Boat is not available in this time");
            }
            var discount = await context.ClientCategories
                .Where(cc => cc.IdClientCategory == client.IdClientCategory)
                .Select(cc => cc.DiscountPerc)
                .FirstOrDefaultAsync();
            price *= 1 - (discount/100);
            
            Console.WriteLine('\n');
            Console.WriteLine($"Price: {price}");
            Console.WriteLine('\n');
            

            var reservation = new Reservation
            {
                IdClient = postReservationRequestModel.IdClient,
                DateFrom = postReservationRequestModel.DateFrom,
                DateTo = postReservationRequestModel.DateTo,
                IdBoatStandard = postReservationRequestModel.IdBoatStandard,
                Capacity = 10,
                NumOfBoats = postReservationRequestModel.NumOfBoats,
                Fulfilled = true,
                Price = price,
                CancelReason = ""
            };

            await context.Reservations.AddAsync(reservation);

            await context.SaveChangesAsync();

            await transaction.CommitAsync();
        }
        catch (NotFoundException e)
        {
            transaction.Rollback();
            throw new NotFoundException(e.Message);
        }
        catch (ArgumentException e)
        {
            transaction.Rollback();
            throw new ArgumentException(e.Message);
        }
        catch (Exception e)
        {
            transaction.Rollback();
            if (e.InnerException != null)
            {
                Console.WriteLine($"Inner Exception: {e.InnerException.Message}");
            }
            throw new Exception(e.Message);
        }

        return true;

    }
}