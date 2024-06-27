using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_13.Models;

[Table("Reservation_Status")]
public class ReservationStatus
{
    [Key][Column("PK")]
    public int PK { get; set; }
    [Column("nam")][Required][MaxLength(50)]
    public string Name { get; set; }

    public List<Reservation> Reservations { get; set; }
}