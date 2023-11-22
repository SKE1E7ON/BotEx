using System;
using System.Collections.Generic;

namespace BotEx_Api.Model;

public partial class StatusRobot
{
    public int StatusRoboId { get; set; }

    public string Status { get; set; } = null!;
    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
