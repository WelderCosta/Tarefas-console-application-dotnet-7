using AprendizadoTS.Models;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoTS.Data
{
    public class DbContextData : DbContext
    {
        public DbContextData(DbContextOptions<DbContextData> options) : base(options)
        {
        }

        public DbSet<MTask> MTask { get; set; }
    }
}
