using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_13.Models;

[Table("Vehicle_Brands")]
public class VehicleBrand
{
    [Key][Column("PK")]
    public int PK { get; set; }
    [Column("name")][Required][MaxLength(50)]
    public string Name { get; set; }

    public List<Vehicle> Vehicles { get; set; }
}