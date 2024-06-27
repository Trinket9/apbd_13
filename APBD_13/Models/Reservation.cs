using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_13.Models;

[Table("Reservations")]
public class Reservation
{
    [Key][Column("PK")]
    public int ReservationID { get; set; }
    [ForeignKey("Customer")][Column("FK_customer")]
    public int CustomerID { get; set; }
    [ForeignKey("Vehicle")][Column("FK_car")]
    public int VehicleID { get; set; }
    [ForeignKey("ReservationStatus")][Column("FK_reservation_status")]
    public int ReservationStatusID { get; set; }
    [Column("from")][Required]
    public DateTime From { get; set; }
    [Column("to")][Required]
    public DateTime To { get; set; }

    public Customer Customer { get; set; }
    public Vehicle Vehicle { get; set; }
    public ReservationStatus ReservationStatus { get; set; }
}