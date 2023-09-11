using Microsoft.EntityFrameworkCore;
using Bai1.Models;

namespace Bai1.Models
{
    public class Bai1DbContext : DbContext
    {
        public Bai1DbContext(DbContextOptions<Bai1DbContext> options) : base(options)
        {
            System.Diagnostics.Debug.WriteLine("AIMSDbContext::ctor ->" + this.GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().ToTable(nameof(Person));
            //modelBuilder.Entity<Person>().HasKey(x => x.Id);

            modelBuilder.Entity<Employee>().ToTable(nameof(Employee));
            modelBuilder.Entity<Employee>().HasKey(x => x.Id);

            modelBuilder.Entity<DaiLy>().ToTable(nameof(DaiLy));
            modelBuilder.Entity<DaiLy>().HasKey(x => x.Id);

            modelBuilder.Entity<HeThongPhanPhoi>().ToTable(nameof(HeThongPhanPhoi));
            modelBuilder.Entity<HeThongPhanPhoi>().HasKey(x => x.Id);
        }

        public DbSet<Bai1.Models.Employee>? Employee { get; set; }

        public DbSet<Bai1.Models.HeThongPhanPhoi>? HeThongPhanPhoi { get; set; }

        public DbSet<Bai1.Models.DaiLy>? DaiLy { get; set; }
    }
}
