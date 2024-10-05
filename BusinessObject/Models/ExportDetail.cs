using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class ExportDetail
{
    public int ExportDetailId { get; set; }

    public int? ExportId { get; set; }

    public int? ProductLineId { get; set; }

    public int? Quantity { get; set; }

    public virtual Export? Export { get; set; }

    public virtual ProductLine? ProductLine { get; set; }
}
