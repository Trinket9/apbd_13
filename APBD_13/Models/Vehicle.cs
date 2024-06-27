using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_13.Models;

[Table("Vehicles")]
public class Vehicle
{
    [Key][Column("PK")]
    public int PK { get; set; }
    [ForeignKey("VehicleType")][Column("FK_vehicle_type")]
    public int VehicleTypeID { get; set; }
    [ForeignKey("VehicleBrand")][Column("FK_vehicle_brand")]
    public int VehicleBrandID { get; set; }
    [Column("model")][Required][MaxLength(50)]
    public string Model { get; set; }
    [Column("num_of_doors")]
    public int Doors { get; set; }
    [Column("num_of_seats")][Required]
    public int Seats { get; set; }
    [Column("year_of_production")][Required]
    public int ProductionYear { get; set; }

    public VehicleBrand VehicleBrand { get; set; }
    public VehicleType VehicleType { get; set; }

    public List<Reservation> Reservations { get; set; }
}