using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prac.Models1;

public partial class PracticaContext : DbContext
{
    public PracticaContext()
    {
    }

    public PracticaContext(DbContextOptions<PracticaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Availability> Availabilities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<MaintenanceRecord> MaintenanceRecords { get; set; }

    public virtual DbSet<MaintenanceType> MaintenanceTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<RentalAgreement> RentalAgreements { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusPayment> StatusPayments { get; set; }

    public virtual DbSet<Technic> Technics { get; set; }

    public virtual DbSet<TechnicType> TechnicTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Port=5432;Database=Practica;Username=postgres;Password=Dyht2006");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Availability>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("availability_pkey");

            entity.ToTable("availability");

            entity.Property(e => e.AvailabilityId)
                .ValueGeneratedNever()
                .HasColumnName("availability_id");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("employee_id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employees_role_id_fkey");
        });

        modelBuilder.Entity<MaintenanceRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("maintenance_records_pkey");

            entity.ToTable("maintenance_records");

            entity.Property(e => e.RecordId)
                .ValueGeneratedNever()
                .HasColumnName("record_id");
            entity.Property(e => e.DatePerformed).HasColumnName("date_performed");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.MaintenanceTypeId).HasColumnName("maintenance_type_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.TechnicId).HasColumnName("technic_id");

            entity.HasOne(d => d.Employee).WithMany(p => p.MaintenanceRecords)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("maintenance_records_employee_id_fkey");

            entity.HasOne(d => d.MaintenanceType).WithMany(p => p.MaintenanceRecords)
                .HasForeignKey(d => d.MaintenanceTypeId)
                .HasConstraintName("maintenance_records_maintenance_type_id_fkey");

            entity.HasOne(d => d.Technic).WithMany(p => p.MaintenanceRecords)
                .HasForeignKey(d => d.TechnicId)
                .HasConstraintName("maintenance_records_technic_id_fkey");
        });

        modelBuilder.Entity<MaintenanceType>(entity =>
        {
            entity.HasKey(e => e.MaintenanceTypeId).HasName("maintenance_type_pkey");

            entity.ToTable("maintenance_type");

            entity.Property(e => e.MaintenanceTypeId)
                .ValueGeneratedNever()
                .HasColumnName("maintenance_type_id");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("order_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TechnicId).HasColumnName("technic_id");
            entity.Property(e => e.TotalCost)
                .HasColumnType("money")
                .HasColumnName("total_cost");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_client_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_status_id_fkey");

            entity.HasOne(d => d.Technic).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TechnicId)
                .HasConstraintName("orders_technic_id_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("payment_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payments_order_id_fkey");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("payments_payment_method_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payments_status_id_fkey");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("payment_method_pkey");

            entity.ToTable("payment_method");

            entity.Property(e => e.PaymentMethodId)
                .ValueGeneratedNever()
                .HasColumnName("payment_method_id");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<RentalAgreement>(entity =>
        {
            entity.HasKey(e => e.AgreementId).HasName("rental_agreements_pkey");

            entity.ToTable("rental_agreements");

            entity.HasIndex(e => e.ClientId, "rental_agreements_client_id_key").IsUnique();

            entity.HasIndex(e => e.EmployeeId, "rental_agreements_employee_id_key").IsUnique();

            entity.HasIndex(e => e.OrderId, "rental_agreements_order_id_key").IsUnique();

            entity.Property(e => e.AgreementId)
                .ValueGeneratedNever()
                .HasColumnName("agreement_id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");

            entity.HasOne(d => d.Client).WithOne(p => p.RentalAgreement)
                .HasForeignKey<RentalAgreement>(d => d.ClientId)
                .HasConstraintName("rental_agreements_client_id_fkey");

            entity.HasOne(d => d.Employee).WithOne(p => p.RentalAgreement)
                .HasForeignKey<RentalAgreement>(d => d.EmployeeId)
                .HasConstraintName("rental_agreements_employee_id_fkey");

            entity.HasOne(d => d.Order).WithOne(p => p.RentalAgreement)
                .HasForeignKey<RentalAgreement>(d => d.OrderId)
                .HasConstraintName("rental_agreements_order_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("Status_pkey");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<StatusPayment>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("Status_payment_pkey");

            entity.ToTable("Status_payment");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Technic>(entity =>
        {
            entity.HasKey(e => e.TechnicId).HasName("technic_pkey");

            entity.ToTable("technic");

            entity.Property(e => e.TechnicId)
                .ValueGeneratedNever()
                .HasColumnName("technic_id");
            entity.Property(e => e.AvailabilityId).HasColumnName("availability_id");
            entity.Property(e => e.ManufactureYear).HasColumnName("manufacture_year");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Availability).WithMany(p => p.Technics)
                .HasForeignKey(d => d.AvailabilityId)
                .HasConstraintName("technic_availability_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.Technics)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("technic_type_id_fkey");
        });

        modelBuilder.Entity<TechnicType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("technic_type_pkey");

            entity.ToTable("technic_type");

            entity.Property(e => e.TypeId)
                .ValueGeneratedNever()
                .HasColumnName("type_id");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("User_Id");
            entity.Property(e => e.Login)
                .HasMaxLength(30)
                .HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
