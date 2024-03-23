using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class VReportUser
{
    public int ReportId { get; set; }

    public int EmId { get; set; }

    public string? WorkContent { get; set; }

    public string? JobDetail { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? Flag { get; set; }

    public int DepId { get; set; }

    public string? DepName { get; set; }
}
