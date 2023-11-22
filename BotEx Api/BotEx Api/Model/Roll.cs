using System;
using System.Collections.Generic;

namespace BotEx_Api.Model;

public partial class Roll
{
    public int RolIdl { get; set; }

    public string Naming { get; set; } = null!;
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
