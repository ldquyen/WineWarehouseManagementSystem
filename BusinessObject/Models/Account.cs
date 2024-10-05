using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? AccountName { get; set; }

    public string? Username { get; set; }

    public string? UserPassword { get; set; }

    public int? AccountRole { get; set; }

    public virtual ICollection<CheckingRequest> CheckingRequests { get; set; } = new List<CheckingRequest>();

    public virtual ICollection<Export> Exports { get; set; } = new List<Export>();

    public virtual ICollection<Import> Imports { get; set; } = new List<Import>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
