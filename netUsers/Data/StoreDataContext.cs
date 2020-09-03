using Microsoft.EntityFrameworkCore;
using netUsers.Data.Maps;
using netUsers.Models;

namespace netUsers.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Server> Servers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost, 1433; Database=netusers; User ID=SA; Password=dante123#");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientMap());
            builder.ApplyConfiguration(new ServerMap());

        }
    }
}