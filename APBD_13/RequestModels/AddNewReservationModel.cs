using System.ComponentModel.DataAnnotations;

namespace APBD_13.RequestModels;

public class AddNewReservationModel
{
    [Required]
    public int VehicleID { get; set; }
    [Required]
    public DateTime From { get; set; }
    [Required]
    public DateTime To { get; set; }
}