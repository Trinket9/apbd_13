using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_13.Models;

[Table("Customers")]
public class Customer
{
    [Key][Column("PK")]
    public int CustomerID { get; set; }
    [Column("first_name")][Required][MaxLength(50)]
    public string FirstName { get; set; }
    [Column("last_name")][Required][MaxLength(50)]
    public string LastName { get; set; }
    [Column("email")][Required][MaxLength(100)]
    public string Email { get; set; }
    [Column("price")][Required][MaxLength(9)]
    public string Phone { get; set; }
    [Column("pesel")][Required][MaxLength(11)]
    public string PESEL { get; set; }

    public List<Reservation> Reservations { get; set; }
}