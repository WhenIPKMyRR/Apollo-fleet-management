using Microsoft.EntityFrameworkCore;
using Models;


namespace Repository {
    public class Context : DbContext 
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Garage> Garages { get; set; }
        public const string _CONNETION = "Server=localhost;User Id=root;Password=Wheniparkmyrr_1234;Database=apollofleetmanagement";
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            { 
                optionsBuilder.UseMySql(_CONNETION, MySqlServerVersion.AutoDetect(_CONNETION)); 
            }
    }
}
