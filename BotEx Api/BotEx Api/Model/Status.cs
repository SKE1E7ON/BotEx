using System;
using System.Collections.Generic;

namespace BotEx_Api.Model;

public partial class Status
{
    public int StatusId { get; set; }

    public string Naming { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
