using Microsoft.EntityFrameworkCore;

namespace Onix_Gym.Models
{
    public class OnixGymDbContext : DbContext
    {
        public OnixGymDbContext(DbContextOptions<OnixGymDbContext> options) : base(options)
        {
        }

        // DbSets para cada modelo
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<HistorialPrice> HistorialPrices { get; set; }
        public DbSet<HistorialSale> HistorialSales { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<SaleMembership> SaleMemberships { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de claves compuestas
            modelBuilder.Entity<SaleDetail>()
                .HasKey(sd => new { sd.SaleId, sd.ProductId });

            modelBuilder.Entity<SaleMembership>()
                .HasKey(sm => new { sm.SaleId, sm.MembershipId });

            // Relación entre Sale y Person (cliente)
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Person)
                .WithMany(p => p.Purchases)
                .HasForeignKey(s => s.PersonId)
                .OnDelete(DeleteBehavior.Restrict); // Desactiva la eliminación en cascada

            // Relación entre Sale y Employe (empleado)
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Employe)
                .WithMany(e => e.Sales)
                .HasForeignKey(s => s.EmployeId)
                .OnDelete(DeleteBehavior.Restrict); // Desactiva la eliminación en cascada

            // Relación entre Product y Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Relación entre Product and Supplier
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId);

            // Relación entre User y Employe
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employe)
                .WithOne(e => e.User)
                .HasForeignKey<Employe>(e => e.UserId);

            // Relación entre User y Role
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
