namespace Picaras.Model
{
    using System.Data.Entity;
    using Entities;

    public partial class PicarasModel : DbContext
    {
        public PicarasModel()
            : base("name=PicarasModel")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<AgentTransport> AgentTransports { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AdminSlider> AdminSlider { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
