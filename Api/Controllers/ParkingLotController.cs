using Microsoft.AspNetCore.Mvc;
using ParkOnyx.Repositories.Interfaces;

namespace ParkOnyx.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ParkingLotController(IParkingLotRepository parkingLotRepository) : ControllerBase
{
    [HttpGet("nearby")]
    public IActionResult GetNearbyParkingLots(double latitude, double longitude, double radiusKm,
        CancellationToken cancellationToken)
    {
        var nearbyParkingLots = parkingLotRepository.SelectAll(cancellationToken).Result
            .Where(lot => CalculateDistance(latitude, longitude, lot.Latitude, lot.Longitude) <= radiusKm)
            .Select(lot => new
            {
                lot.Id,
                lot.Name,
                lot.Location,
                lot.Latitude,
                lot.Longitude,
                lot.TotalSpots,
                lot.AvailableSpots
            })
            .ToList();

        return Ok(nearbyParkingLots);
    }

    // Haversine formula to calculate distance between two points
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