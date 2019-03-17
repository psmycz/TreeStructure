using StrukturaDrzewiasta.Core.Domain;
using StrukturaDrzewiasta.Persistance.EntityConfigurations;
using System.Data.Entity;

namespace StrukturaDrzewiasta.Persistance
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            this.Configuration.LazyLoadingEnabled = true;
            
        }


        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}