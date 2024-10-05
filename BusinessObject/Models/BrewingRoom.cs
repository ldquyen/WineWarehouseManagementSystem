using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class BrewingRoom
{
    public int BrewingRoomId { get; set; }

    public string? RoomName { get; set; }

    public int? Temperature { get; set; }

    public int? Humidity { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<Shelf> Shelves { get; set; } = new List<Shelf>();
}
