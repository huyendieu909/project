using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Bai10_Quy_440
{
    public class QLLuongContext : DbContext
    {
        public QLLuongContext() : base("Data Source=HUYEN-DIEU-ACER;Initial Catalog=QLLuong;Integrated Security=True") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<DonVi> DonVis {  get; set; }
    }
}