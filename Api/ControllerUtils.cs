using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Core;

public class ControllerUtils
{
    public static Guid GetUserIdFromToken(ControllerBase controller)
    {
        var userIdString = controller.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.Parse(userIdString!);
    }
}