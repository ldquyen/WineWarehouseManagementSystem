using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public int? ProductLineId { get; set; }

    public int? CheckingRequestId { get; set; }

    public int? StockQuantity { get; set; }

    public int? CheckedQuantity { get; set; }

    public DateOnly? CheckedDate { get; set; }

    public string? Reason { get; set; }

    public int? AccountId { get; set; }

    public bool? ReportStatus { get; set; }

    public virtual Account? Account { get; set; }

    public virtual CheckingRequest? CheckingRequest { get; set; }

    public virtual ProductLine? ProductLine { get; set; }
}
