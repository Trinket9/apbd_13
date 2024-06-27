using APBD_13.Exceptions;
using APBD_13.RequestModels;
using APBD_13.Services;

namespace APBD_13.Endpoints;

public static class ReservationEndpoint
{
    public static void RegisterUserEndpoints(this RouteGroupBuilder builder) {
        var group = builder.MapGroup("customers");
        group.MapGet("{id_customer:int}/reservations", GetReservationsByStatusDetails);
        group.MapPost("{id_customer:int}/reservations", AddOrder);
    }
    
    private static async Task<IResult> GetReservationsByStatusDetails(int id_customer, string? status, 
        CancellationToken cancellationToken, IReservationService service) {
        try {
            var result = await service.GetReservationsByStatus(id_customer, status, cancellationToken);
            return Results.Ok(result);
        }
        catch (NotFoundException e) {
            return Results.NotFound(e.Message);
        }
    }

    private static async Task<IResult> AddOrder(int id_customer, List<AddNewReservationModel> request, 
        IReservationService service, CancellationToken cancellationToken) {
        try {
            service.AddReservation(id_customer, request, cancellationToken);
            return Results.NoContent();
        }
        catch (NotFoundException e) {
            return Results.NotFound(e.Message);
        }
        catch (BadRequestException e) {
            return Results.BadRequest(e.Message);
        }
    }
}