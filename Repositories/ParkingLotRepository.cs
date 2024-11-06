using ParkOnyx.Entities;
using ParkOnyx.Repositories.Contexts;
using ParkOnyx.Repositories.Interfaces;

namespace ParkOnyx.Repositories;

public class ParkingLotRepository : BaseRepository<ParkingLotEntity>, IParkingLotRepository
{
    public ParkingLotRepository(DataContext context) : base(context)
    {
    }
}