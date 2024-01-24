using api_crud_net.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api_crud_net.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Usuarios");
            modelBuilder.Entity<Product>().ToTable("Produtos");
            modelBuilder.Entity<Order>().ToTable("Pedidos");

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .HasColumnName("UsuID")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1,1);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .HasColumnName("UsuNome")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasColumnName("UsuPass")
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .HasColumnName("ProdID")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1,1);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasColumnName("ProdDesc")
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnName("ProdPrice")
                .HasColumnType("Money");

            modelBuilder.Entity<Order>()
                .Property(o => o.Id)
                .HasColumnName("PedID")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1,1);

            modelBuilder.Entity<Order>()
                .Property(o => o.UserId)
                .HasColumnName("PedUsu")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.ProductId)
                .HasColumnName("PedProd")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.UnitPrice)
                .HasColumnName("PedVrUnit")
                .HasColumnType("Money")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.Quantity)
                .HasColumnName("PedCant")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.Subtotal)
                .HasColumnName("PedSubTotal")
                .HasColumnType("Money")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.Iva)
                .HasColumnName("PedIVA")
                .HasColumnName("Decimal(5,2)")
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.Total)
                .HasColumnName("PedTotal")
                .HasColumnType("Money")
                .IsRequired(); 

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
    }
}
