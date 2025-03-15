using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project.Models
{
    public partial class p02_efarmingContext : DbContext
    {
        public p02_efarmingContext()
        {
        }

        public p02_efarmingContext(DbContextOptions<p02_efarmingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Farmerproducttype> Farmerproducttypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Orderdetail> Orderdetails { get; set; } = null!;
        public virtual DbSet<PaymentMode> PaymentModes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Producttype> Producttypes { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=p02_efarming", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.Bno)
                    .HasName("PRIMARY");

                entity.ToTable("bill");

                entity.HasIndex(e => e.Bno, "bno_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Mid, "mid_idx");

                entity.HasIndex(e => e.TransactionId, "transaction_id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Ubid, "ubid_idx");

                entity.Property(e => e.Bno).HasColumnName("bno");

                entity.Property(e => e.Amt).HasColumnName("amt");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Mid).HasColumnName("mid");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(45)
                    .HasColumnName("transaction_id");

                entity.Property(e => e.Ubid).HasColumnName("ubid");

                entity.HasOne(d => d.MidNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Mid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mid");

                entity.HasOne(d => d.Ub)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.Ubid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ubid");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PRIMARY");

                entity.ToTable("city");

                entity.HasIndex(e => e.Cid, "cid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Cname)
                    .HasMaxLength(255)
                    .HasColumnName("cname");
            });

            modelBuilder.Entity<Farmerproducttype>(entity =>
            {
                entity.HasKey(e => e.Fptid)
                    .HasName("PRIMARY");

                entity.ToTable("farmerproducttype");

                entity.HasIndex(e => e.Fptid, "fptid_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Ptid, "ptfpid_idx");

                entity.HasIndex(e => e.Uid, "ufpid_idx");

                entity.Property(e => e.Fptid).HasColumnName("fptid");

                entity.Property(e => e.Images).HasColumnName("images");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Ptid).HasColumnName("ptid");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.Pt)
                    .WithMany(p => p.Farmerproducttypes)
                    .HasForeignKey(d => d.Ptid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ptid");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Farmerproducttypes)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uid");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PRIMARY");

                entity.ToTable("order");

                entity.HasIndex(e => e.Oid, "oid_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Uoid, "uoid_idx");

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Odate).HasColumnName("odate");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.Property(e => e.Uoid).HasColumnName("uoid");

                entity.HasOne(d => d.Uo)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Uoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uoid");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.HasKey(e => e.Odid)
                    .HasName("PRIMARY");

                entity.ToTable("orderdetails");

                entity.HasIndex(e => e.Odid, "d_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Fptoiod, "fptoid_idx");

                entity.HasIndex(e => e.Oid, "oid_idx");

                entity.Property(e => e.Odid).HasColumnName("odid");

                entity.Property(e => e.Fptoiod).HasColumnName("fptoiod");

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.FptoiodNavigation)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Fptoiod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fptoid");

                entity.HasOne(d => d.OidNavigation)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("oid");
            });

            modelBuilder.Entity<PaymentMode>(entity =>
            {
                entity.HasKey(e => e.Mid)
                    .HasName("PRIMARY");

                entity.ToTable("payment_mode");

                entity.Property(e => e.Mid).HasColumnName("mid");

                entity.Property(e => e.Mname)
                    .HasMaxLength(15)
                    .HasColumnName("mname");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.Pid, "pid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Pname)
                    .HasMaxLength(255)
                    .HasColumnName("pname");
            });

            modelBuilder.Entity<Producttype>(entity =>
            {
                entity.HasKey(e => e.Ptid)
                    .HasName("PRIMARY");

                entity.ToTable("producttype");

                entity.HasIndex(e => e.Ptid, "pid_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Pid, "pid_idx");

                entity.Property(e => e.Ptid).HasColumnName("ptid");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Ptname)
                    .HasMaxLength(255)
                    .HasColumnName("ptname");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Producttypes)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pid");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Rid)
                    .HasName("PRIMARY");

                entity.ToTable("role");

                entity.HasIndex(e => e.Rid, "rid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Rname)
                    .HasMaxLength(255)
                    .HasColumnName("rname");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.Adhaar, "adhaar_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Cid, "cid_idx");

                entity.HasIndex(e => e.Email, "email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Pwd, "pwd_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Rid, "rid_idx");

                entity.HasIndex(e => e.Uid, "uid_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Uname, "uname_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .HasColumnName("address");

                entity.Property(e => e.Adhaar).HasColumnName("adhaar");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Contact)
                    .HasMaxLength(255)
                    .HasColumnName("contact");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Fname)
                    .HasMaxLength(255)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .HasMaxLength(255)
                    .HasColumnName("lname");

                entity.Property(e => e.Pwd).HasColumnName("pwd");

                entity.Property(e => e.Rid).HasColumnName("rid");

                entity.Property(e => e.Uname).HasColumnName("uname");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cid");

                entity.HasOne(d => d.RidNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
