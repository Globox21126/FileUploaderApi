using Microsoft.EntityFrameworkCore;

namespace CanonImgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Img> Imgs { get; set; }
    }
}
