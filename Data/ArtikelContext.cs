using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;

namespace it_shop_app.Data 
{
    public class ArtikelContext : DbContext
    {
        public ArtikelContext (DbContextOptions<ArtikelContext> options) 
            : base(options) 
        { }

        public DbSet<Artikel> Artikel { get; set; }
    }
}