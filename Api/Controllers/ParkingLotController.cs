using Microsoft.AspNetCore.Mvc;
using ParkOnyx.Repositories.Interfaces;
using ParkOnyx.Services.Interfaces;

namespace ParkOnyx.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ParkingLotController(IParkingLotService parkingLotService) : ControllerBase
{
    [HttpGet("nearby")]
    public async Task<IActionResult> GetNearbyParkingLots(double latitude, double longitude, double radiusKm,
        CancellationToken cancellationToken)
    {
        var nearbyParkingLots = await parkingLotService
            .GetNearbyParkingLots(latitude, longitude, radiusKm, cancellationToken);

        return Ok(nearbyParkingLots);
    }
}