using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pr17KS.Models;

public partial class ExamResultContext : DbContext
{
    public ExamResultContext()
    {
    }

    public ExamResultContext(DbContextOptions<ExamResultContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SessionsResult> SessionsResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=ExamResult;User=исп-34;Password=1234567890;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SessionsResult>(entity =>
        {
            entity.HasKey(e => e.SudentId).HasName("PK__Sessions__D1690EF75645CAB5");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(3);
            entity.Property(e => e.GroupIndex).HasMaxLength(10);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MaritalStatus).HasMaxLength(20);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
