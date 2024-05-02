using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Models;

public partial class ChatUsersContext : DbContext
{
    public ChatUsersContext()
    {
    }

    public ChatUsersContext(DbContextOptions<ChatUsersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Utenti> Utentis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-BFLNTHU7\\SQLEXPRESS;Initial Catalog=ChatUsers;Encrypt=False;Trusted_Connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Utenti__CB9A1CDF28107582");

            entity.ToTable("Utenti");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Codice)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codice");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.ProfileImg)
                .HasColumnType("text")
                .HasColumnName("profileImg");
            entity.Property(e => e.Psw)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("psw");
            entity.Property(e => e.UserType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("USER")
                .HasColumnName("userType");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
