using Data.Context.Configuration;
using Data.DataSources;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DatabaseContext: DbContext
    {
        public DbSet<ClientDataSource> Clients { get; set; }
        public DbSet<GuitarDataSource> Guitars { get; set; }
        public DbSet<OrderDataSource> Orders { get; set; }
        public DbSet<CompositionDataSource> Compositions { get; set; }
        
        // N : N
        public DbSet<ActiveOrderDataSource> ActiveOrders { get; set; }
        public DbSet<SelectedCompositionDataSource> SelectedComposition { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseNpgsql("Host=localhost;Port=5432;Database=icm;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // [Order] -> N: [ActiveOrder] :N <- [Guitar]
            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasKey(k => new {k.OrderId, k.GuitarId});

            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasOne(sc => sc.Guitar)
                .WithMany(s => s.Orders)
                .HasForeignKey(sc => sc.GuitarId);

            modelBuilder.Entity<ActiveOrderDataSource>()
                .HasOne(sc => sc.Order)
                .WithMany(s => s.Orders)
                .HasForeignKey(sc => sc.OrderId);
            
            // [Guitar] -> N: [SelectedComposition] :N <- [Composition]
            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasKey(k => new {k.GuitarId, k.CompositionId});

            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasOne(sc => sc.Guitar)
                .WithMany(s => s.Compositions)
                .HasForeignKey(sc => sc.GuitarId);

            modelBuilder.Entity<SelectedCompositionDataSource>()
                .HasOne(sc => sc.Composition)
                .WithMany(s => s.Compositions)
                .HasForeignKey(sc => sc.CompositionId);
                
            base.OnModelCreating(modelBuilder);
        }
    }
}