using ParkOnyx.Entities;
using ParkOnyx.Repositories.Interfaces;
using ParkOnyx.Services.Interfaces;

namespace ParkOnyx.Services;

public class ParkingLotService(IParkingLotRepository parkingLotRepository) : IParkingLotService
{
    public async Task<List<ParkingLotEntity>> GetNearbyParkingLots(double latitude, double longitude, double radiusKm,
        CancellationToken cancellationToken)
    {
        var parkingLots = await parkingLotRepository.SelectAll(cancellationToken);
        var nearbyParkingLots = parkingLots
            .Where(lot => CalculateDistance(latitude, longitude, lot.Latitude, lot.Longitude) <= radiusKm)
            .Select(lot => new ParkingLotEntity
            {
                Id = lot.Id,
                Name = lot.Name,
                Location = lot.Location,
                Latitude = lot.Latitude,
                Longitude = lot.Longitude,
                TotalSpots = lot.TotalSpots,
                AvailableSpots = lot.AvailableSpots
            })
            .ToList();

        return nearbyParkingLots;
    }

    private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
    {
        var R = 6371; // Radius of the earth in km
        var dLat = (lat2 - lat1) * Math.PI / 180;
        var dLon = (lon2 - lon1) * Math.PI / 180;
        var a =
            Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return R * c; // Distance in km
    }
}