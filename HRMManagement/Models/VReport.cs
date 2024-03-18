using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class VReport
{
    public int ReportId { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? FirstName { get; set; }

    public string? DepName { get; set; }

    public string? WorkContent { get; set; }

    public string? JobDetail { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Flag { get; set; }

    public int EmId { get; set; }

    public int DepId { get; set; }
}
