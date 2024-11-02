namespace ParkOnyx.Entities;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class UserEntity : BaseEntity
{
    [Required] [MaxLength(50)] public string Username { get; set; } // Unique, Max Length: 50

    public byte[]? PasswordHash { get; init; }
    public byte[]? PasswordSalt { get; init; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } // Unique, Max Length: 100

    [Required] [MaxLength(10)] public string Role { get; set; } // E.g., "User" or "Owner", Max Length: 10

    // Relationships
    public ICollection<ReservationEntity> Reservations { get; set; }
    public ICollection<ParkingLotEntity> OwnedParkingLots { get; set; }
}