using Microsoft.EntityFrameworkCore;
using mobilsentra.Core.Models;
namespace mobilsentra.Persistence
{
    public class MobilSentraDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
         public DbSet<Vehicle> Vehicles { get; set; }
         public DbSet<Model> Models { get; set; }
        public MobilSentraDbContext(DbContextOptions<MobilSentraDbContext> options)
            : base(options)
        {            
            
        }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleFeature>().
                HasKey(vf => new{
                    vf.VehicleId,
                    vf.FeatureId
                });
        }    
        
    }
}