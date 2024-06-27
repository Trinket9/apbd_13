using APBD_13.Models;

namespace APBD_13.ResponseModels;

public class GetCustomerReservationsByStatusResponseModel
{
    public List<ReservationModel> Reservations { get; set; }
}

public class ReservationModel
{
    public int VehicleID { get; set; }
    public Status Status { get; set; }
    public string VehicleBrand { get; set; }
    public string VehicleType { get; set; }
    public string Model { get; set; }
    public int YearOfProduction { get; set; }
    public int NumberOfDoors { get; set; }
    public int NumberOfSeats { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}

public enum Status
{
    SUBMITTED, CANCELLED, REALIZED
}