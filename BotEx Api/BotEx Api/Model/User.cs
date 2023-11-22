using System;
using System.Collections.Generic;


namespace BotEx_Api.Model;

public partial class User
{
    public int UsersId { get; set; }

    public string Loggin { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string AdresDefalt { get; set; } = null!;

    public string CardDefalt { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int IdRole { get; set; }
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public virtual Roll IdRoleNavigation { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
