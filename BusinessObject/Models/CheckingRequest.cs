using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class CheckingRequest
{
    public int CheckingRequestId { get; set; }

    public int? AccountId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? CheckDateRequest { get; set; }

    public string? Reason { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Product? Product { get; set; }
}
