using Microsoft.EntityFrameworkCore;
using PruebaTabla.Models;

namespace PruebaTabla.DataAcces
{
    public class PruebaTablaDbContext : DbContext
    {
        public PruebaTablaDbContext(DbContextOptions<PruebaTablaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //    //optionsBuilder.UseSqlServer(@"Data Source = localhost; Initial Catalog = SMSAsignaciones; Integrated Security = true");
        //    optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;Database=PruebaTabla_Db; Trusted_Connection=true;");
        //    //    //comentar OnConfiguring  cuando  se configure en BASE del constructor
        //}

        public DbSet<Usuario> Usuarios { get; set; }
    
    }
}
