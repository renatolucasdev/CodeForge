using BasicCustomerService.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BasicCustomerService.Data
{
    public class ApiDbContext : IdentityDbContext

    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Configurações do Identity

            modelBuilder.Ignore<Person>(); // Remove Person do mapeamento

            modelBuilder.Entity<Customer>().ToTable("Customers"); // Customer será uma única tabela com todos os atributos
        }

    }
}
