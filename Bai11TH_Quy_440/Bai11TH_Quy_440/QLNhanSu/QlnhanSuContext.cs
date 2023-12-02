using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Bai11TH_Quy_440.QLNhanSu;

public partial class QlnhanSuContext : DbContext
{
    public QlnhanSuContext()
    {
    }

    public QlnhanSuContext(DbContextOptions<QlnhanSuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HUYEN-DIEU-ACER;Initial Catalog=QLNhanSu;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A681EC73D");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaNV");
            entity.Property(e => e.Gioitinh).HasMaxLength(3);
            entity.Property(e => e.HoTen).HasMaxLength(30);
            entity.Property(e => e.MaPb)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaPB");
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.NgoaiNgu).HasMaxLength(20);

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPb)
                .HasConstraintName("FK__NhanVien__MaPB__398D8EEE");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPb).HasName("PK__PhongBan__2725E7E4102D98F0");

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPb)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MaPB");
            entity.Property(e => e.TenPb)
                .HasMaxLength(30)
                .HasColumnName("TenPB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
