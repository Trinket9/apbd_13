using APBD_13.Context;
using APBD_13.Models;
using System.Linq;
using APBD_13.Exceptions;
using APBD_13.RequestModels;
using APBD_13.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace APBD_13.Services;

public interface IReservationService
{
    public Task<GetCustomerReservationsByStatusResponseModel> GetReservationsByStatus(int customerID, string status,
        CancellationToken cancellationToken);

    public Task AddReservation(int id_customer, AddNewReservationModel newReservationModels,
        CancellationToken cancellationToken);
    
}

public class ReservationService : IReservationService 
{
    private readonly DatabaseContext _context;

    public ReservationService(DatabaseContext context) {
        this._context = context;
    }

    public async Task<GetCustomerReservationsByStatusResponseModel> GetReservationsByStatus(int customerID, string status,
        CancellationToken cancellationToken) {
        var allowedStatuses = new[] { "SUBMITTED", "CANCELLED", "REALIZED" };

        if (!allowedStatuses.Contains(status.ToUpper()))
        {
            throw new ArgumentException("Invalid status value. Allowed values are SUBMITTED, CANCELLED, REALIZED.");
        }
        
        List<Reservation> reservation = _context.Reservations
            .Where(r => r.CustomerID == customerID && r.ReservationStatus.Name == status.ToUpper())
            .ToList();

        //unfinished
        var response = new GetCustomerReservationsByStatusResponseModel {
            Reservations = new List<ReservationModel> { }
        };
        
        return response;
        
    }

    public async Task AddReservation(int customerID, AddNewReservationModel newReservationModels,
        CancellationToken cancellationToken) {
        var customer = await _context.Customers.FindAsync(customerID);
        if (customer == null)
        {
            throw new NotFoundException($"Customer with ID {customerID} not found.");
        }
        
        var conflictingReservation = _context.Reservations
            .FirstOrDefault(r =>
                r.VehicleID == newReservationModels.VehicleID &&
                r.ReservationStatusID == 1 &&
                r.From <= newReservationModels.To && r.To >= newReservationModels.From);
        
        if (conflictingReservation != null)
        {
            throw new AlreadyReservedException("There is a conflicting reservation for the same car.");
        }
        
        var reservation = new Reservation
        {
            CustomerID = customerID,
            From = newReservationModels.From,
            To = newReservationModels.To,
            ReservationStatusID = 1 
        };

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync(cancellationToken);
        
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }
}