using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class ProductLine
{
    public int ProductLineId { get; set; }

    public int? ProductId { get; set; }

    public int? ProductYear { get; set; }

    public int? ProductAlcohol { get; set; }

    public int? Capacity { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public int? ShelfId { get; set; }

    public virtual ICollection<ExportDetail> ExportDetails { get; set; } = new List<ExportDetail>();

    public virtual ICollection<ImportDetail> ImportDetails { get; set; } = new List<ImportDetail>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual Shelf? Shelf { get; set; }
}
