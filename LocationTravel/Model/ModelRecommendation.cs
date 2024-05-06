using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LocationTravel.Model
{
    public partial class ModelRecommendation : DbContext
    {
        public ModelRecommendation()
            : base("name=ModelRecommendation")
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<TypeLocation> TypeLocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(e => e.Cost)
                .HasPrecision(18, 0);
        }
    }
}
