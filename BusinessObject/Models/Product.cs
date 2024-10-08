using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models;

public partial class Product
{
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Product name is required.")]
    public string? ProductName { get; set; }
    [Required(ErrorMessage = "Product description is required.")]
    public string? ProductDescription { get; set; }
    [Required(ErrorMessage = "Origin is required.")]
    public string? Origin { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<CheckingRequest> CheckingRequests { get; set; } = new List<CheckingRequest>();

    public virtual ICollection<ProductLine> ProductLines { get; set; } = new List<ProductLine>();
}
