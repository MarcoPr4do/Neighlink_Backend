using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NeighLink.DateLayer.Models
{
    public partial class neighlinkdbContext : DbContext
    {
        public neighlinkdbContext()
        {
        }

        public neighlinkdbContext(DbContextOptions<neighlinkdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Building> Building { get; set; }
        public virtual DbSet<Condominium> Condominium { get; set; }
        public virtual DbSet<Condominiumrule> Condominiumrule { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Option> Option { get; set; }
        public virtual DbSet<OptionResident> OptionResident { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Paymentcategory> Paymentcategory { get; set; }
        public virtual DbSet<Planmember> Planmember { get; set; }
        public virtual DbSet<Poll> Poll { get; set; }
        public virtual DbSet<Resident> Resident { get; set; }
        public virtual DbSet<ResidentDepartment> ResidentDepartment { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=neighlink-dev-server.mysql.database.azure.com;database=neighlinkdb;uid=marcoliva@neighlink-dev-server;pwd=Neighlink20", x => x.ServerVersion("5.7.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.ToTable("administrator");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Administrator_User_idx");

                entity.Property(e => e.AdministratorId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Administrator)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Admin_User");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => new { e.BillId, e.PaymentCategoryId })
                    .HasName("PRIMARY");

                entity.ToTable("bill");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("fk_Bill_Department1_idx");

                entity.HasIndex(e => e.PaymentCategoryId)
                    .HasName("fk_Bill_PaymentCategory1_idx");

                entity.Property(e => e.BillId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PaymentCategoryId).HasColumnType("int(11)");

                entity.Property(e => e.AdministratorId).HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnType("decimal(10,0)");

                entity.Property(e => e.CondominiumId).HasColumnType("int(11)");

                entity.Property(e => e.DepartmentId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("building");

                entity.HasIndex(e => e.CondominiumId)
                    .HasName("fk_Building_Condominium1_idx");

                entity.Property(e => e.BuildingId).HasColumnType("int(11)");

                entity.Property(e => e.CondominiumId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NumberOfHomes).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Condominium>(entity =>
            {
                entity.ToTable("condominium");

                entity.HasIndex(e => e.AdministratorId)
                    .HasName("fk_Condominium_Administrator1_idx");

                entity.Property(e => e.CondominiumId).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.AdministratorId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Condominiumrule>(entity =>
            {
                entity.ToTable("condominiumrule");

                entity.HasIndex(e => e.CondominiumId)
                    .HasName("fk_CondominiumRule_Condominium1_idx");

                entity.Property(e => e.CondominiumRuleId).HasColumnType("int(11)");

                entity.Property(e => e.CondominiumId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("department");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("fk_Department_Building1_idx");

                entity.Property(e => e.DepartmentId).HasColumnType("int(11)");

                entity.Property(e => e.BuildingId).HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.CondominiumId).HasColumnType("int(11)");

                entity.Property(e => e.LimitRegister).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.HasIndex(e => e.CondominiumId)
                    .HasName("fk_News_Condominium1_idx");

                entity.Property(e => e.NewsId).HasColumnType("int(11)");

                entity.Property(e => e.CondominiumId).HasColumnType("int(11)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Option>(entity =>
            {
                entity.ToTable("option");

                entity.HasIndex(e => e.PollId)
                    .HasName("fk_Option_Poll1_idx");

                entity.Property(e => e.OptionId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PollId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<OptionResident>(entity =>
            {
                entity.HasKey(e => new { e.OptionResidentId, e.OptionId, e.ResidentId, e.ResidentUserId })
                    .HasName("PRIMARY");

                entity.ToTable("option_resident");

                entity.HasIndex(e => e.OptionId)
                    .HasName("fk_Option_Resident_Option1_idx");

                entity.HasIndex(e => new { e.ResidentId, e.ResidentUserId })
                    .HasName("fk_Option_Resident_Resident1_idx");

                entity.Property(e => e.OptionResidentId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OptionId).HasColumnType("int(11)");

                entity.Property(e => e.ResidentId).HasColumnType("int(11)");

                entity.Property(e => e.ResidentUserId)
                    .HasColumnName("Resident_UserId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => new { e.PaymentId, e.ResidentId, e.ResidentUserId })
                    .HasName("PRIMARY");

                entity.ToTable("payment");

                entity.HasIndex(e => e.BillId)
                    .HasName("fk_Payment_Bill1_idx");

                entity.HasIndex(e => new { e.ResidentId, e.ResidentUserId })
                    .HasName("fk_Payment_Resident1_idx");

                entity.Property(e => e.PaymentId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ResidentId).HasColumnType("int(11)");

                entity.Property(e => e.ResidentUserId)
                    .HasColumnName("Resident_UserId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amount).HasColumnType("decimal(10,0)");

                entity.Property(e => e.BillId).HasColumnType("int(11)");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.UrlImage)
                    .HasColumnName("urlImage")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Paymentcategory>(entity =>
            {
                entity.ToTable("paymentcategory");

                entity.Property(e => e.PaymentCategoryId).HasColumnType("int(11)");

                entity.Property(e => e.CondominiumId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Planmember>(entity =>
            {
                entity.ToTable("planmember");

                entity.HasIndex(e => e.AdministratorId)
                    .HasName("fk_PlanMember_Administrator1_idx");

                entity.Property(e => e.PlanMemberId).HasColumnType("int(11)");

                entity.Property(e => e.AdministratorId).HasColumnType("int(11)");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DatePayed).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10,0)");
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.ToTable("poll");

                entity.HasIndex(e => e.CondominiumId)
                    .HasName("fk_Poll_Condominium1_idx");

                entity.Property(e => e.PollId).HasColumnType("int(11)");

                entity.Property(e => e.AdministratorId).HasColumnType("int(11)");

                entity.Property(e => e.CondominiumId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.HasKey(e => new { e.ResidentId, e.UserId })
                    .HasName("PRIMARY");

                entity.ToTable("resident");

                entity.Property(e => e.ResidentId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<ResidentDepartment>(entity =>
            {
                entity.HasKey(e => new { e.ResidentDepartmentId, e.DepartmentId })
                    .HasName("PRIMARY");

                entity.ToTable("resident_department");

                entity.HasIndex(e => e.DepartmentId)
                    .HasName("fk_Resident_Department_Department1_idx");

                entity.HasIndex(e => e.ResidentId)
                    .HasName("fk_Resident_Department_Resident1_idx");

                entity.Property(e => e.ResidentDepartmentId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DepartmentId).HasColumnType("int(11)");

                entity.Property(e => e.BuildingId).HasColumnType("int(11)");

                entity.Property(e => e.CondiminiumId).HasColumnType("int(11)");

                entity.Property(e => e.ResidentId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Gender)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Phone)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Token)
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
