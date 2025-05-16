using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Menu;
using BuberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence
{
    public class BuberDinnerDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options)
            : base(options) 
        { 
        }

        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Host> Hosts { get; set; } = null!;
        public DbSet<Dinner> Dinners { get; set; } = null!;
        public DbSet<Guest> Guests { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
