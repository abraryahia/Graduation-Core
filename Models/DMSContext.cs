using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Graduation_Core.Models
{
    public partial class DMSContext : DbContext
    {
        public DMSContext()
        {
        }

        public DMSContext(DbContextOptions<DMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calculations> Calculations { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<CityDetails> CityDetails { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<PackagesInfo> PackagesInfo { get; set; }
        public virtual DbSet<ReceiverInfo> ReceiverInfo { get; set; }
        public virtual DbSet<SenderInfo> SenderInfo { get; set; }
        public virtual DbSet<UsersDetails> UsersDetails { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;database=DMS;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Calculations>(entity =>
            {
                entity.HasKey(e => e.CalcId);

                entity.Property(e => e.CalcId)
                    .HasColumnName("Calc_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CalcEarly).HasColumnName("Calc_Early");

                entity.Property(e => e.CalcFragile).HasColumnName("Calc_fragile");

                entity.Property(e => e.CalcWeight).HasColumnName("Calc_Weight");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.Property(e => e.CId)
                    .HasColumnName("C_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CLat).HasColumnName("C_Lat");

                entity.Property(e => e.CLong).HasColumnName("C_Long");

                entity.Property(e => e.CName)
                    .HasColumnName("C_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.DayOfTravel)
                    .IsRequired()
                    .HasColumnName("Day_Of_Travel")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CityDetails>(entity =>
            {
                entity.HasKey(e => e.CDId);

                entity.ToTable("City_Details");

                entity.Property(e => e.CDId)
                    .HasColumnName("C_D_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.TCName)
                    .IsRequired()
                    .HasColumnName("T_C_NAME")
                    .HasMaxLength(100);

                entity.HasOne(d => d.C)
                    .WithMany(p => p.CityDetails)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_Details_City");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.EmpAddress)
                    .IsRequired()
                    .HasColumnName("Emp_ADDRESS")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpAddressDetails)
                    .HasColumnName("Emp_ADDRESS_DETAILS")
                    .HasMaxLength(150);

                entity.Property(e => e.EmpCId).HasColumnName("Emp_C_ID");

                entity.Property(e => e.EmpEmail)
                    .HasColumnName("Emp_EMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLId).HasColumnName("Emp_L_ID");

                entity.Property(e => e.EmpMobile)
                    .IsRequired()
                    .HasColumnName("Emp_MOBILE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasColumnName("Emp_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.EmpSsn)
                    .IsRequired()
                    .HasColumnName("Emp_SSN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmpC)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmpCId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_City");

                entity.HasOne(d => d.EmpL)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmpLId)
                    .HasConstraintName("FK_Employee_Locations");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LId);

                entity.Property(e => e.LId).HasColumnName("L_ID");

                entity.Property(e => e.CId).HasColumnName("C_ID");

                entity.Property(e => e.LFrom)
                    .IsRequired()
                    .HasColumnName("L_FROM")
                    .HasMaxLength(50);

                entity.Property(e => e.LTo)
                    .IsRequired()
                    .HasColumnName("L_TO")
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations_City");
            });

            modelBuilder.Entity<PackagesInfo>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.ToTable("Packages_Info");

                entity.Property(e => e.PId)
                    .HasColumnName("P_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Deleverydate)
                    .HasColumnName("DELEVERYDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(150);

                entity.Property(e => e.Earlydelivery)
                    .HasColumnName("EARLYDELIVERY")
                    .HasMaxLength(50);

                entity.Property(e => e.PDeliverStatus)
                    .IsRequired()
                    .HasColumnName("P_DELIVER_STATUS")
                    .HasMaxLength(50);

                entity.Property(e => e.PFaragial)
                    .IsRequired()
                    .HasColumnName("P_FARAGIAL")
                    .HasMaxLength(50);

                entity.Property(e => e.PLId).HasColumnName("P_L_ID");

                entity.Property(e => e.PPrice).HasColumnName("P_PRICE");

                entity.Property(e => e.PWeight).HasColumnName("P_WEIGHT");

                entity.Property(e => e.RSsn)
                    .IsRequired()
                    .HasColumnName("R_SSN")
                    .HasMaxLength(50);

                entity.Property(e => e.SSsn)
                    .IsRequired()
                    .HasColumnName("S_SSN")
                    .HasMaxLength(50);

                entity.HasOne(d => d.PL)
                    .WithMany(p => p.PackagesInfo)
                    .HasForeignKey(d => d.PLId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Packages_Info_Locations");
            });

            modelBuilder.Entity<ReceiverInfo>(entity =>
            {
                entity.HasKey(e => e.RId);

                entity.ToTable("Receiver_Info");

                entity.Property(e => e.RId)
                    .HasColumnName("R_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RAddress)
                    .IsRequired()
                    .HasColumnName("R_ADDRESS")
                    .HasMaxLength(50);

                entity.Property(e => e.RAddressDetail)
                    .HasColumnName("R_ADDRESS_DETAIL")
                    .HasMaxLength(250);

                entity.Property(e => e.RCDId).HasColumnName("R_C_D_ID");

                entity.Property(e => e.RCId).HasColumnName("R_C_ID");

                entity.Property(e => e.REmail)
                    .HasColumnName("R_EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.RMobile)
                    .IsRequired()
                    .HasColumnName("R_MOBILE")
                    .HasMaxLength(50);

                entity.Property(e => e.RName)
                    .IsRequired()
                    .HasColumnName("R_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.RSsn)
                    .IsRequired()
                    .HasColumnName("R_SSN")
                    .HasMaxLength(50);

                entity.Property(e => e.SId).HasColumnName("S_ID");

                entity.HasOne(d => d.S)
                    .WithMany(p => p.ReceiverInfo)
                    .HasForeignKey(d => d.SId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receiver_Info_Sender_Info");
            });

            modelBuilder.Entity<SenderInfo>(entity =>
            {
                entity.HasKey(e => e.SId);

                entity.ToTable("Sender_Info");

                entity.Property(e => e.SId)
                    .HasColumnName("S_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SAddress)
                    .IsRequired()
                    .HasColumnName("S_ADDRESS")
                    .HasMaxLength(50);

                entity.Property(e => e.SAddressDetail)
                    .HasColumnName("S_ADDRESS_DETAIL")
                    .HasMaxLength(150);

                entity.Property(e => e.SCDId).HasColumnName("S_C_D_ID");

                entity.Property(e => e.SCId).HasColumnName("S_C_ID");

                entity.Property(e => e.SEmail)
                    .HasColumnName("S_EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.SMobile)
                    .IsRequired()
                    .HasColumnName("S_MOBILE")
                    .HasMaxLength(50);

                entity.Property(e => e.SName)
                    .IsRequired()
                    .HasColumnName("S_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.SSsn)
                    .IsRequired()
                    .HasColumnName("S_SSN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UsersDetails>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("Users_Details");

                entity.Property(e => e.UserId)
                    .HasColumnName("USER_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleId).HasColumnName("ROLE_ID");

                entity.Property(e => e.UserFullName)
                    .IsRequired()
                    .HasColumnName("USER_FULL_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("USER_PASSWORD")
                    .HasMaxLength(50);

                entity.Property(e => e.UsrName)
                    .IsRequired()
                    .HasColumnName("USR_NAME")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UsersDetails)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Details_Users_Roles");
            });

            modelBuilder.Entity<UsersRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("Users_Roles");

                entity.Property(e => e.RoleId)
                    .HasColumnName("ROLE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeleteAllowed)
                    .HasColumnName("DELETE_ALLOWED")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.InsertAllowed)
                    .HasColumnName("INSERT_ALLOWED")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.QueryAllowed)
                    .HasColumnName("QUERY_ALLOWED")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.RoleDesc)
                    .HasColumnName("ROLE_DESC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .HasColumnName("ROLE_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateAllowed)
                    .HasColumnName("UPDATE_ALLOWED")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });
        }
    }
}
