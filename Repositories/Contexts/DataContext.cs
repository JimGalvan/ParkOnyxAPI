using Microsoft.EntityFrameworkCore;
using ParkOnyx.Entities;

namespace ParkOnyx.Repositories.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> UserEntities { get; set; }
    public DbSet<Reservation> ReservationEntities { get; set; }
    public DbSet<ParkingLot> ParkingLotEntities { get; set; }
    public DbSet<ParkingSpot> ParkingSpotEntities { get; set; }
}