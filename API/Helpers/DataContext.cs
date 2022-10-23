using API.Data;
using Microsoft.EntityFrameworkCore;


namespace API.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        // saver db my sql
        public DbSet<Product> products { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<DetailOrder> detailOrders { get; set; }

        //https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx
        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<Product>(e =>
            {
                e.ToTable("AppProduct");
            });
            m.Entity<TypeProduct>(e =>
            {
                e.ToTable("AppTypeProduct");
            });
            m.Entity<Order>(e =>
            {
                e.ToTable("AppOrder");
                e.HasKey(o => o.OrderId);
                e.Property(o => o.OrderDate).HasDefaultValue(DateTime.Now);
                e.Property(o => o.Recipient).IsRequired().HasMaxLength(100);
            });
            m.Entity<DetailOrder>(e =>
            {
                e.ToTable("AppDetailOrder");
                e.HasKey(d => new {d.OrderId, d.ProductId});
                e.HasOne(d => d.Order).WithMany(d => d.DetailOrders).HasForeignKey(d => d.OrderId).HasConstraintName("FK_DetailOrder_Order");
                e.HasOne(d => d.Product).WithMany(d => d.DetailOrders).HasForeignKey(d => d.ProductId).HasConstraintName("FK_DetailOrder_Product");
            });
        }
    }
}