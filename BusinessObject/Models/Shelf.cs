using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Shelf
{
    public int ShelfId { get; set; }

    public int? BrewingRoomId { get; set; }

    public string? ShelfName { get; set; }

    public int? MaxQuantity { get; set; }

    public int? UseQuantity { get; set; }

    public virtual BrewingRoom? BrewingRoom { get; set; }

    public virtual ICollection<ProductLine> ProductLines { get; set; } = new List<ProductLine>();
}
