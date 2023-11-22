using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BotEx_Api.Model;

public partial class ProjectContext : DbContext
{
    public ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<RestoType> RestoTypes { get; set; }

    public virtual DbSet<Restoran> Restorans { get; set; }

    public virtual DbSet<Roll> Rolls { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusRobot> StatusRobots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;password=root;database=project", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PRIMARY");

            entity.ToTable("delivery");

            entity.HasIndex(e => e.RobotStatus, "stat_idx");

            entity.Property(e => e.DeliveryId)
                .ValueGeneratedNever()
                .HasColumnName("Delivery_id");
            entity.Property(e => e.EmployeeInformation)
                .HasMaxLength(45)
                .HasColumnName("Employee_Information");
            entity.Property(e => e.RobotAvailability)
                .HasMaxLength(45)
                .HasColumnName("Robot_Availability");
            entity.Property(e => e.RobotBattery).HasColumnName("Robot_Battery");
            entity.Property(e => e.RobotLocation)
                .HasMaxLength(45)
                .HasColumnName("Robot_Location");
            entity.Property(e => e.RobotName)
                .HasMaxLength(45)
                .HasColumnName("Robot_Name");
            entity.Property(e => e.RobotStatus).HasColumnName("Robot_Status");

            entity.HasOne(d => d.RobotStatusNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.RobotStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliv_stat");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PRIMARY");

            entity.ToTable("feedback");

            entity.HasIndex(e => e.IdOrders, "feed_order_idx");

            entity.HasIndex(e => e.IdUsers, "feed_user_idx");

            entity.Property(e => e.FeedbackId)
                .ValueGeneratedNever()
                .HasColumnName("Feedback_id");
            entity.Property(e => e.IdDeliveryRate).HasColumnName("id_Delivery_rate");
            entity.Property(e => e.IdOrders).HasColumnName("id_Orders");
            entity.Property(e => e.IdRestoRate).HasColumnName("Id_Resto_rate");
            entity.Property(e => e.IdUsers).HasColumnName("id_Users");
            entity.Property(e => e.Text).HasMaxLength(45);

            entity.HasOne(d => d.IdOrdersNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.IdOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("feed_order");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.IdUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("feed_user");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PRIMARY");

            entity.ToTable("menu");

            entity.HasIndex(e => e.IdResto, "men_resto_idx");

            entity.Property(e => e.MenuId)
                .ValueGeneratedNever()
                .HasColumnName("Menu_id");
            entity.Property(e => e.Cost).HasMaxLength(45);
            entity.Property(e => e.IdResto).HasColumnName("id_Resto");
            entity.Property(e => e.Image).HasMaxLength(45);
            entity.Property(e => e.Info)
                .HasMaxLength(225)
                .HasColumnName("info");
            entity.Property(e => e.Naming).HasMaxLength(45);
            entity.Property(e => e.Sale).HasMaxLength(45);

            entity.HasOne(d => d.IdRestoNavigation).WithMany(p => p.Menus)
                .HasForeignKey(d => d.IdResto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("men_resto");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrders).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.IdDelivery, "order_deliv_idx");

            entity.HasIndex(e => e.IdMenu, "order_menu_idx");

            entity.HasIndex(e => e.IdResto, "order_resto_idx");

            entity.HasIndex(e => e.IdUsers, "order_user_idx");

            entity.HasIndex(e => e.Status, "orders_status_idx");

            entity.Property(e => e.IdOrders)
                .ValueGeneratedNever()
                .HasColumnName("idOrders");
            entity.Property(e => e.Cost).HasMaxLength(45);
            entity.Property(e => e.Data).HasMaxLength(45);
            entity.Property(e => e.IdDelivery).HasColumnName("id_Delivery");
            entity.Property(e => e.IdMenu).HasColumnName("id_Menu");
            entity.Property(e => e.IdResto).HasColumnName("id_Resto");
            entity.Property(e => e.IdUsers).HasColumnName("id_Users");
            entity.Property(e => e.Photo).HasMaxLength(45);

            entity.HasOne(d => d.IdDeliveryNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdDelivery)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_deliv");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_menu");

            entity.HasOne(d => d.IdRestoNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdResto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_resto");

            entity.HasOne(d => d.IdUsersNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_user");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_status");
        });

        modelBuilder.Entity<RestoType>(entity =>
        {
            entity.HasKey(e => e.RestoTypeId).HasName("PRIMARY");

            entity.ToTable("resto_type");

            entity.Property(e => e.RestoTypeId)
                .ValueGeneratedNever()
                .HasColumnName("Resto_type_id");
            entity.Property(e => e.Naming).HasMaxLength(45);
        });

        modelBuilder.Entity<Restoran>(entity =>
        {
            entity.HasKey(e => e.RestoransId).HasName("PRIMARY");

            entity.ToTable("restorans");

            entity.HasIndex(e => e.Type, "resto_type_idx");

            entity.Property(e => e.RestoransId)
                .ValueGeneratedNever()
                .HasColumnName("Restorans_id");
            entity.Property(e => e.Adres).HasMaxLength(45);
            entity.Property(e => e.CostRate).HasColumnName("Cost_rate");
            entity.Property(e => e.Image).HasMaxLength(45);
            entity.Property(e => e.Info).HasMaxLength(225);
            entity.Property(e => e.Naming).HasMaxLength(45);
            entity.Property(e => e.UserRate).HasColumnName("User_rate");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Restorans)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("resto_type");
        });

        modelBuilder.Entity<Roll>(entity =>
        {
            entity.HasKey(e => e.RolIdl).HasName("PRIMARY");

            entity.ToTable("roll");

            entity.Property(e => e.RolIdl)
                .ValueGeneratedNever()
                .HasColumnName("rol_idl");
            entity.Property(e => e.Naming).HasMaxLength(45);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("Status_id");
            entity.Property(e => e.Naming).HasMaxLength(45);
        });

        modelBuilder.Entity<StatusRobot>(entity =>
        {
            entity.HasKey(e => e.StatusRoboId).HasName("PRIMARY");

            entity.ToTable("status_robot");

            entity.Property(e => e.StatusRoboId)
                .ValueGeneratedNever()
                .HasColumnName("status_robo_id");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdRole, "role_idx");

            entity.Property(e => e.UsersId)
                .ValueGeneratedNever()
                .HasColumnName("Users_id");
            entity.Property(e => e.AdresDefalt)
                .HasMaxLength(45)
                .HasColumnName("Adres_defalt");
            entity.Property(e => e.CardDefalt)
                .HasMaxLength(45)
                .HasColumnName("Card_defalt");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Loggin).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Phone).HasMaxLength(45);

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
