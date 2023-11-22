using System;
using System.Collections.Generic;

namespace BotEx_Api.Model;

public partial class Order
{
    public int IdOrders { get; set; }

    public int IdUsers { get; set; }

    public int IdResto { get; set; }

    public int IdDelivery { get; set; }

    public int IdMenu { get; set; }

    public int Status { get; set; }

    public string Cost { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public string Data { get; set; } = null!;
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public virtual Delivery IdDeliveryNavigation { get; set; } = null!;
    public virtual Menu IdMenuNavigation { get; set; } = null!;
    public virtual Restoran IdRestoNavigation { get; set; } = null!;
    public virtual User IdUsersNavigation { get; set; } = null!;
    public virtual Status StatusNavigation { get; set; } = null!;
}
