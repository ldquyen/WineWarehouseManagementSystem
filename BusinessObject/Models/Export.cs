using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Export
{
    public int ExportId { get; set; }

    public DateOnly? ExportDate { get; set; }

    public int? AccountId { get; set; }

    public string? Note { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<ExportDetail> ExportDetails { get; set; } = new List<ExportDetail>();
}
