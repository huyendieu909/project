using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Bai9_Quy440_P3
{
    public class QLLuongContext : DbContext
    {
        public QLLuongContext() : base("Data Source=HUYEN-DIEU-ACER;Initial Catalog=QLLuong;Integrated Security=True;") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<DonVi> DonVis {  get; set; }
    }
}