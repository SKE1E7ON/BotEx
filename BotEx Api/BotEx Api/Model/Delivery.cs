using System;
using System.Collections.Generic;

namespace BotEx_Api.Model;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public string RobotName { get; set; } = null!;

    public int RobotStatus { get; set; }

    public string RobotLocation { get; set; } = null!;

    public string RobotAvailability { get; set; } = null!;

    public int RobotBattery { get; set; }

    public string EmployeeInformation { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual StatusRobot RobotStatusNavigation { get; set; } = null!;
}
