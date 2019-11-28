using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Data 
{
    public class ShopContext : DbContext
    {
        public ShopContext (DbContextOptions<ShopContext> options) 
            : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {           
            // Beziehung Artikel 1 <--> n Merkmal
            modelBuilder.Entity<Merkmal>()
                .HasOne<Artikel>(m => m.Artikel)
                .WithMany(a => a.Merkmale)
                .HasForeignKey(m => m.Artikel_ID);

            // Beziehung Nutzer 1 <--> n Bestellungen
            modelBuilder.Entity<Bestellung>()
                .HasOne<Nutzer>(b => b.Kaeufer)
                .WithMany(n => n.Bestellungen)
                .HasForeignKey(b => b.Nutzer_ID);

            // Beziehung Bestellungen n <--> m Artikel
            modelBuilder.Entity<ArtikelBestellungen>().HasKey(ab => new { ab.Artikel_ID, ab.Bestellung_ID });
                // ArtikelBestellungen n <--> 1 Bestellungen
                modelBuilder.Entity<ArtikelBestellungen>()
                    .HasOne<Bestellung>(ab => ab.Bestellung)
                    .WithMany(b => b.ArtikelBestellungen)
                    .HasForeignKey(ab => ab.Bestellung_ID);

                // ArtikelBestellungen n <--> 1 Artikel
                modelBuilder.Entity<ArtikelBestellungen>()
                    .HasOne<Artikel>(ab => ab.Artikel)
                    .WithMany(a => a.ArtikelBestellungen)
                    .HasForeignKey(ab => ab.Artikel_ID);


            // Beziehung Nutzer n <--> m Artikel === Warenkorb
            modelBuilder.Entity<Warenkorb>().HasKey(ab => new { ab.Nutzer_ID, ab.Artikel_ID });
                // Warenkorb n <--> 1 Nutzer
                modelBuilder.Entity<Warenkorb>()
                    .HasOne<Nutzer>(w => w.Nutzer)
                    .WithMany(n => n.Warenkorb)
                    .HasForeignKey(w => w.Nutzer_ID);

                // Warenkorb n <--> 1 Artikel
                modelBuilder.Entity<Warenkorb>()
                    .HasOne<Artikel>(w => w.Artikel)
                    .WithMany(a => a.Warenkorb)
                    .HasForeignKey(w => w.Artikel_ID);

            // Beziehung Nutzer 1 <--> n Listen
            modelBuilder.Entity<Liste>()
                .HasOne<Nutzer>(l => l.Nutzer)
                .WithMany(n => n.Listen)
                .HasForeignKey(l => l.Nutzer_ID);

            // Beziehung Warenkorb n <--> m Artikel
            modelBuilder.Entity<ListenArtikel>().HasKey(ab => new { ab.Liste_ID, ab.Artikel_ID });
                // ArtikelBestellungen n <--> 1 Warenkorb
                modelBuilder.Entity<ListenArtikel>()
                    .HasOne<Liste>(ab => ab.Liste)
                    .WithMany(b => b.ListenArtikel)
                    .HasForeignKey(ab => ab.Liste_ID);

                // ArtikelBestellungen n <--> 1 Artikel
                modelBuilder.Entity<ListenArtikel>()
                    .HasOne<Artikel>(ab => ab.Artikel)
                    .WithMany(a => a.ListenArtikel)
                    .HasForeignKey(ab => ab.Artikel_ID);
        }

        public DbSet<Merkmal> Merkmale { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Nutzer> Nutzer { get; set; }
        public DbSet<Warenkorb> Warenkoerbe { get; set; }
        public DbSet<Liste> Listen { get; set; }
        // Zuordnungstabellen
        public DbSet<ArtikelBestellungen> ArtikelBestellungen { get; set; }
        public DbSet<Warenkorb> Warenkorb { get; set; }
        public DbSet<ListenArtikel> ListenArtikel { get; set; }
    }
}