using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDescription { get; set; }

    public string? Origin { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductDetailId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<CheckingRequest> CheckingRequests { get; set; } = new List<CheckingRequest>();

    public virtual ICollection<ProductLine> ProductLines { get; set; } = new List<ProductLine>();
}
