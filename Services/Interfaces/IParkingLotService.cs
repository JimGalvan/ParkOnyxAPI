using ParkOnyx.Entities;

namespace ParkOnyx.Services.Interfaces;

public interface IParkingLotService
{
    Task<List<ParkingLotEntity>> GetNearbyParkingLots(double latitude, double longitude, double radiusKm,
        CancellationToken cancellationToken);
}