global using Microsoft.EntityFrameworkCore;
using QuanLyHangHoa.Models;

namespace QuanLyHangHoa.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=KURONEJIAOI\\SQL2019; Database=qlhanghoa; Trusted_Connection=true; TrustServerCertificate=true;");
        }

        #region Fluent API
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        #endregion

        public DbSet<HangHoaModel> HangHoas { get; set; }
    }
}
