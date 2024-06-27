using APBD_13.Context;
using APBD_13.Models;
using System.Linq;
using APBD_13.Exceptions;
using APBD_13.RequestModels;
using APBD_13.ResponseModels;

namespace APBD_13.Services;

public interface IReservationService
{
    public Task<GetCustomerReservationsByStatusResponseModel> GetReservationsByStatus(int customerID, string status,
        CancellationToken cancellationToken);

    public Task AddReservation(int id_customer, List<AddNewReservationModel> newReservationModels,
        CancellationToken cancellationToken);
    
}

public class ReservationService : IReservationService
{
    private readonly DatabaseContext _context;

    public ReservationService(DatabaseContext context) {
        this._context = context;
    }

    public Task<GetCustomerReservationsByStatusResponseModel> GetReservationsByStatus(int customerID, string status,
        CancellationToken cancellationToken) {
        var allowedStatuses = new[] { "SUBMITTED", "CANCELLED", "REALIZED" };
        if (!allowedStatuses.Contains(status.ToUpper()))
        {
            throw new BadRequestException("Invalid status value. Allowed values are SUBMITTED, CANCELLED, REALIZED.");
        }

        List<Reservation> reservations = _reservationService.GetReservationsByStatus(id_customer, status);
        return Ok(reservations);
    }

    public Task AddReservation(int id_customer, List<AddNewReservationModel> newReservationModels,
        CancellationToken cancellationToken) {
        
    }
}