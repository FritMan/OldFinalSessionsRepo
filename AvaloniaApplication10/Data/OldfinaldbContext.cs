using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace AvaloniaApplication10.Data;

public partial class OldfinaldbContext : DbContext
{
    public OldfinaldbContext()
    {
    }

    public OldfinaldbContext(DbContextOptions<OldfinaldbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Matrix> Matrices { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Pattercritical> Pattercriticals { get; set; }

    public virtual DbSet<Patternnotification> Patternnotifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Paymentandvending> Paymentandvendings { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productsinvending> Productsinvendings { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicepriority> Servicepriorities { get; set; }

    public virtual DbSet<Statusvending> Statusvendings { get; set; }

    public virtual DbSet<Timezone> Timezones { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vending> Vendings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=oldfinaldb;uid=root;pwd=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("company");

            entity.HasIndex(e => e.UserId, "UserCompany_idx");

            entity.Property(e => e.Address).HasMaxLength(145);
            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.SiteAddress).HasMaxLength(145);
            entity.Property(e => e.Status).HasMaxLength(145);

            entity.HasOne(d => d.User).WithMany(p => p.Companies)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserCompany");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mark");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Matrix>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("matrix");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("model");

            entity.HasIndex(e => e.MarkId, "MarkModel_idx");

            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasOne(d => d.Mark).WithMany(p => p.Models)
                .HasForeignKey(d => d.MarkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MarkModel");
        });

        modelBuilder.Entity<Pattercritical>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("pattercritical");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Patternnotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("patternnotifications");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Paymentandvending>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paymentandvending");

            entity.HasIndex(e => e.PaymentId, "PayId_idx");

            entity.HasIndex(e => e.VendingId, "VenId_idx");

            entity.HasOne(d => d.Payment).WithMany(p => p.Paymentandvendings)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PayId");

            entity.HasOne(d => d.Vending).WithMany(p => p.Paymentandvendings)
                .HasForeignKey(d => d.VendingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VenId");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.Cost).HasPrecision(10, 2);
            entity.Property(e => e.Description).HasMaxLength(145);
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Productsinvending>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productsinvending");

            entity.HasIndex(e => e.ProductId, "ProductId_idx");

            entity.HasIndex(e => e.VendingId, "Ven1Id_idx");

            entity.HasOne(d => d.Product).WithMany(p => p.Productsinvendings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProductId");

            entity.HasOne(d => d.Vending).WithMany(p => p.Productsinvendings)
                .HasForeignKey(d => d.VendingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ven1Id");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sales");

            entity.HasIndex(e => e.PaymentId, "PaymentSaleId_idx");

            entity.HasIndex(e => e.ProductId, "ProductSaleId_idx");

            entity.HasIndex(e => e.VenId, "VendingSaleID_idx");

            entity.Property(e => e.DatetimeSale).HasColumnType("datetime");

            entity.HasOne(d => d.Payment).WithMany(p => p.Sales)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PaymentSaleId");

            entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProductSaleId");

            entity.HasOne(d => d.Ven).WithMany(p => p.Sales)
                .HasForeignKey(d => d.VenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("VendingSaleID");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("service");

            entity.HasIndex(e => e.UserId, "ServiceUserId_idx");

            entity.HasIndex(e => e.VendingId, "ServiceVenId_idx");

            entity.Property(e => e.DateTimeService).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(145);
            entity.Property(e => e.DescriptionError).HasMaxLength(145);

            entity.HasOne(d => d.User).WithMany(p => p.Services)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ServiceUserId");

            entity.HasOne(d => d.Vending).WithMany(p => p.Services)
                .HasForeignKey(d => d.VendingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ServiceVenId");
        });

        modelBuilder.Entity<Servicepriority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("servicepriority");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Statusvending>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("statusvending");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<Timezone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("timezone");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.RoleId, "UserRole_idx");

            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.Patronimic).HasMaxLength(45);
            entity.Property(e => e.Phone).HasMaxLength(45);
            entity.Property(e => e.Photo).HasColumnType("blob");
            entity.Property(e => e.Surname).HasMaxLength(45);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("UserRole");
        });

        modelBuilder.Entity<Vending>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("vending");

            entity.HasIndex(e => e.ClientId, "ClientVendingId_idx");

            entity.HasIndex(e => e.EngineerId, "EngineerVendingId_idx");

            entity.HasIndex(e => e.ManagerId, "ManagerVendingId_idx");

            entity.HasIndex(e => e.MatrixId, "MatrixVendingId_idx");

            entity.HasIndex(e => e.ModeId, "ModeVendingId_idx");

            entity.HasIndex(e => e.ModelSlaveId, "Model_SlaveVendingId_idx");

            entity.HasIndex(e => e.PatternCritValueId, "PatternCritVendingId_idx");

            entity.HasIndex(e => e.PatternNotificationsId, "PatternNotificationsVendingId_idx");

            entity.HasIndex(e => e.ServPriorityId, "ServPirorityVendingId_idx");

            entity.HasIndex(e => e.StatusId, "StatusVendingId_idx");

            entity.HasIndex(e => e.TechnicianId, "TechnicianVendingId_idx");

            entity.HasIndex(e => e.TimeZoneId, "TimeZoneVendingId_idx");

            entity.Property(e => e.Address).HasMaxLength(145);
            entity.Property(e => e.DateInstall).HasColumnType("datetime");
            entity.Property(e => e.Location).HasMaxLength(145);
            entity.Property(e => e.Longitude).HasMaxLength(45);
            entity.Property(e => e.ModelSlaveId).HasColumnName("Model_SlaveId");
            entity.Property(e => e.Modem).HasMaxLength(145);
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Num).HasMaxLength(145);
            entity.Property(e => e.RfidDownload).HasMaxLength(145);
            entity.Property(e => e.RfidIncas).HasMaxLength(145);
            entity.Property(e => e.RfidServ).HasMaxLength(145);
            entity.Property(e => e.TimeWork).HasMaxLength(45);
            entity.Property(e => e.Width).HasMaxLength(45);

            entity.HasOne(d => d.Client).WithMany(p => p.VendingClients)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("ClientVendingId");

            entity.HasOne(d => d.Engineer).WithMany(p => p.VendingEngineers)
                .HasForeignKey(d => d.EngineerId)
                .HasConstraintName("EngineerVendingId");

            entity.HasOne(d => d.Manager).WithMany(p => p.VendingManagers)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("ManagerVendingId");

            entity.HasOne(d => d.Matrix).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.MatrixId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MatrixVendingId");

            entity.HasOne(d => d.Mode).WithMany(p => p.VendingModes)
                .HasForeignKey(d => d.ModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ModeVendingId");

            entity.HasOne(d => d.ModelSlave).WithMany(p => p.VendingModelSlaves)
                .HasForeignKey(d => d.ModelSlaveId)
                .HasConstraintName("Model_SlaveVendingId");

            entity.HasOne(d => d.PatternCritValue).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.PatternCritValueId)
                .HasConstraintName("PatternCritVendingId");

            entity.HasOne(d => d.PatternNotifications).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.PatternNotificationsId)
                .HasConstraintName("PatternNotificationsVendingId");

            entity.HasOne(d => d.ServPriority).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.ServPriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ServPirorityVendingId");

            entity.HasOne(d => d.Status).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StatusVendingId");

            entity.HasOne(d => d.Technician).WithMany(p => p.VendingTechnicians)
                .HasForeignKey(d => d.TechnicianId)
                .HasConstraintName("TechnicianVendingId");

            entity.HasOne(d => d.TimeZone).WithMany(p => p.Vendings)
                .HasForeignKey(d => d.TimeZoneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TimeZoneVendingId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
