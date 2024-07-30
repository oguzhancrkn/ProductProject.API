using ProductProject.API.Core;

namespace ProductProject.API.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        public DbSet<ProductEntity> ProductEntities { get; set; }

    }
  
}
