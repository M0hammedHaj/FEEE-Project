using System;
using System.Collections.Generic;
using FEEE.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace FEEE.Infrastructure.Persistence.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<OperationType> OperationTypes { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentArchive> StudentArchives { get; set; }

    public virtual DbSet<StudentPromotion> StudentPromotions { get; set; }

    public virtual DbSet<StudentSubject> StudentSubjects { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Semester> Semesters { get; set; }
    public virtual DbSet<Year> Years { get; set; }
    public virtual DbSet<HigherYearRequest> HigherYearRequests { get; set; }
    public virtual DbSet<HigherYearRequestSubject> HigherYearRequestSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=FEEEDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); // مهم لانه بفتش عن كل كلاسات اللي بتطبق ال  IEntityTypeConfiguration<T>

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
