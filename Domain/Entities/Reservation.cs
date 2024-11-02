﻿namespace ParkOnyx.Entities;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Reservation : BaseEntity
{
    [Required] public DateTime StartTime { get; set; } // Reservation start time

    [Required] public DateTime EndTime { get; set; } // Reservation end time

    [Required] public bool IsPaid { get; set; } // Whether the reservation has been paid

    // Foreign Keys
    [Required] public Guid UserId { get; set; }
    [ForeignKey("UserId")] public User User { get; set; }

    [Required] public Guid ParkingSpotId { get; set; }
    [ForeignKey("ParkingSpotId")] public ParkingSpot Spot { get; set; }
}