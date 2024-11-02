using Microsoft.EntityFrameworkCore;
using ParkOnyx.Entities;

namespace ParkOnyx.Repositories.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<User> UserEntities { get; init; }
    public DbSet<Reservation> ReservationEntities { get; init; }
    public DbSet<ParkingLot> ParkingLotEntities { get; init; }
    public DbSet<ParkingSpot> ParkingSpotEntities { get; init; }
}