using System;
using System.Collections.Generic;

namespace BotEx_Api.Model;

public partial class RestoType
{
    public int RestoTypeId { get; set; }

    public string Naming { get; set; } = null!;
    public virtual ICollection<Restoran> Restorans { get; set; } = new List<Restoran>();
}
