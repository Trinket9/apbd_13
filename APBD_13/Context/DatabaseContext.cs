using APBD_13.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_13.Context;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleBrand> VehicleBrands { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<ReservationStatus> ReservationStatus { get; set; }
    
    protected DatabaseContext() { }

    public DatabaseContext(DbContextOptions options) : base(options) { }
}