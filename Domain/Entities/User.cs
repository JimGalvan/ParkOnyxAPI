namespace ParkOnyx.Entities;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class User : BaseEntity
{
    [Required] [MaxLength(50)] public string Username { get; set; } // Unique, Max Length: 50

    [Required] [MaxLength(255)] public string Password { get; set; } // Hashed Password, Max Length: 255

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } // Unique, Max Length: 100

    [Required] [MaxLength(10)] public string Role { get; set; } // E.g., "User" or "Owner", Max Length: 10

    // Relationships
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<ParkingLot> OwnedParkingLots { get; set; }
}