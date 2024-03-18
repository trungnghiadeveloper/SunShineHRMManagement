using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Loaibh
{
    public int Id { get; set; }

    public string? TenLoai { get; set; }

    public virtual ICollection<Baohiem> Baohiems { get; } = new List<Baohiem>();
}
