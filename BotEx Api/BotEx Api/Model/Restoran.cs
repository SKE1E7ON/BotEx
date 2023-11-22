using System;
using System.Collections.Generic;


namespace BotEx_Api.Model;

public partial class Restoran
{
    public int RestoransId { get; set; }

    public int Type { get; set; }

    public string Naming { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public string Info { get; set; } = null!;

    public int UserRate { get; set; }

    public int CostRate { get; set; }

    public string Image { get; set; } = null!;
    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual RestoType TypeNavigation { get; set; } = null!;
}
