using Microsoft.EntityFrameworkCore;
using ParkOnyx.Entities;
using ParkOnyx.Repositories.Contexts;

namespace ParkOnyx.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context)
{
}