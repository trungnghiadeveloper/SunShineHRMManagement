using System;
using System.Collections.Generic;

namespace HRMManagement.Models;

public partial class Loaihd
{
    public int Id { get; set; }

    public string? TenLoai { get; set; }

    public virtual ICollection<Hopdong> Hopdongs { get; } = new List<Hopdong>();
}
