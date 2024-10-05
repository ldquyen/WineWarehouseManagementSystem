using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class ImportDetail
{
    public int ImportDetailId { get; set; }

    public int? ImportId { get; set; }

    public int? ProductLineId { get; set; }

    public int? Quantity { get; set; }

    public virtual Import? Import { get; set; }

    public virtual ProductLine? ProductLine { get; set; }
}
