using System;
using System.Collections.Generic;
using HorrorBankDAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HorrorBankDAL
{
    public partial class horrorbankContext : DbContext
    {
        private string connectionString { get; set; }
        public horrorbankContext(string conString)
        {
            this.connectionString = conString;
        }

        public horrorbankContext(DbContextOptions<horrorbankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; } = null!;
        public virtual DbSet<UserCrendential> UserCrendentials { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("pk_AccountNumber");

                entity.ToTable("user_account");

                entity.Property(e => e.AccountNumber)
                    .HasColumnType("numeric(4, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Balance).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.UserId).HasColumnType("numeric(4, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__user_acco__UserI__2A4B4B5E");
            });

            modelBuilder.Entity<UserCrendential>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("pk_UserName");

                entity.ToTable("user_crendentials");

                entity.Property(e => e.UserName)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnType("numeric(4, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCrendentials)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__user_cren__UserI__276EDEB3");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_UserId");

                entity.ToTable("user_profile");

                entity.HasIndex(e => e.EmailId, "uq_EmailId")
                    .IsUnique();

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(4, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
