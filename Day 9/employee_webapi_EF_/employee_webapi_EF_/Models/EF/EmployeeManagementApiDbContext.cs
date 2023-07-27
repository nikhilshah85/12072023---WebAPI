using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace employee_webapi_EF_.Models.EF;

public partial class EmployeeManagementApiDbContext : DbContext
{
    public EmployeeManagementApiDbContext()
    {
    }

    public EmployeeManagementApiDbContext(DbContextOptions<EmployeeManagementApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptInfo> DeptInfos { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=employeeManagementAPI_DB;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptInfo>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__deptInfo__BE2D3F55BA1F5664");

            entity.ToTable("deptInfo");

            entity.Property(e => e.DeptNo)
                .ValueGeneratedNever()
                .HasColumnName("deptNo");
            entity.Property(e => e.DeptLocation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptLocation");
            entity.Property(e => e.DeptName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__employee__AFB33592576E5055");

            entity.ToTable("employeeDetails");

            entity.Property(e => e.EmpNo)
                .ValueGeneratedNever()
                .HasColumnName("empNo");
            entity.Property(e => e.EmpDeptno).HasColumnName("empDeptno");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empDesignation");
            entity.Property(e => e.EmpIsPermenant).HasColumnName("empIsPermenant");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.EmpSalary).HasColumnName("empSalary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
