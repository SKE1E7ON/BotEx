using System;
using System.Collections.Generic;

namespace BotEx_Api.Model;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int IdUsers { get; set; }

    public int IdOrders { get; set; }

    public string Text { get; set; } = null!;

    public int IdRestoRate { get; set; }

    public int IdDeliveryRate { get; set; }

    public virtual Order IdOrdersNavigation { get; set; } = null!;

    public virtual User IdUsersNavigation { get; set; } = null!;
}
