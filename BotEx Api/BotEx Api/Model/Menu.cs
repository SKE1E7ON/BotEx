using System;
using System.Collections.Generic;

namespace BotEx_Api.Model;

public partial class Menu
{
    public int MenuId { get; set; }

    public int IdResto { get; set; }

    public string Naming { get; set; } = null!;

    public string Cost { get; set; } = null!;

    public string Info { get; set; } = null!;

    public string Image { get; set; } = null!;

    public string Sale { get; set; } = null!;
    public virtual Restoran IdRestoNavigation { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
