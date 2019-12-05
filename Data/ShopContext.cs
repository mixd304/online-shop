using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Areas.Identity.Data;
using System;

namespace it_shop_app.Data 
{
    public class ShopContext : IdentityDbContext<IdentityNutzer>
    {
        public ShopContext (DbContextOptions<ShopContext> options) 
            : base(options) 
        { }

        public DbSet<MerkmalBezeichnung> MerkmalBezeichnungen { get; set; }
        public DbSet<Merkmal> Merkmale { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Liste> Listen { get; set; }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<Kommentar> Kommentare { get; set; }
        public DbSet<IdentityNutzer> Nutzer { get; set; }
        public DbSet<Farbe> Farben { get; set; }
        // Zuordnungstabellen
        public DbSet<ArtikelFarben> ArtikelFarben { get; set; }
        public DbSet<ArtikelBestellung> ArtikelBestellungen { get; set; }
        public DbSet<Warenkorb> Warenkoerbe { get; set; }
        public DbSet<ListenArtikel> ListenArtikel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {     
            base.OnModelCreating(modelBuilder);
            //Primärschlüssel
            modelBuilder.Entity<Artikel>().HasKey(a => new { a.ID });
            modelBuilder.Entity<ArtikelFarben>().HasKey(ab => new { ab.Artikel_ID, ab.Farbe_ID });
            modelBuilder.Entity<Farbe>().HasKey(f => new { f.ID });
            modelBuilder.Entity<Kategorie>().HasKey(ka => new { ka.ID });
            modelBuilder.Entity<Kommentar>().HasKey(ko => new { ko.ID });
            modelBuilder.Entity<Merkmal>().HasKey(m => new { m.ID });
            modelBuilder.Entity<MerkmalBezeichnung>().HasKey(mb => new { mb.ID });

            modelBuilder.Entity<Bestellung>().HasKey(b => new { b.ID });
            modelBuilder.Entity<ArtikelBestellung>().HasKey(ab => new { ab.ID });

            modelBuilder.Entity<Liste>().HasKey(l => new { l.ID });
            modelBuilder.Entity<ListenArtikel>().HasKey(la => new { la.Liste_ID, la.Artikel_ID });
            modelBuilder.Entity<Warenkorb>().HasKey(w => new { w.ID });

            // Beziehung MerkmalBezeichnung 1 <--> n Merkmal
            modelBuilder.Entity<Merkmal>()
                .HasOne<MerkmalBezeichnung>(m => m.Bezeichnung)
                .WithMany(mb => mb.Merkmale)
                .HasForeignKey(m => m.Bezeichnung_ID);


            // Beziehung Artikel 1 <--> n Merkmal
            modelBuilder.Entity<Merkmal>()
                .HasOne<Artikel>(m => m.Artikel)
                .WithMany(a => a.Merkmale)
                .HasForeignKey(m => m.Artikel_ID);

            // Beziehung Nutzer 1 <--> n Bestellungen
            modelBuilder.Entity<Bestellung>()
                .HasOne<IdentityNutzer>(b => b.Kaeufer)
                .WithMany(n => n.Bestellungen)
                .HasForeignKey(b => b.Nutzer_ID);
            modelBuilder.Entity<Bestellung>()
                .Property(s => s.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (Stati)Enum.Parse(typeof(Stati), v));

            // Beziehung Nutzer 1 <--> n Listen
            modelBuilder.Entity<Liste>()
                .HasOne<IdentityNutzer>(l => l.Nutzer)
                .WithMany(n => n.Listen)
                .HasForeignKey(l => l.Nutzer_ID);

            // Farbe 1 <--> n Warenkorb
            modelBuilder.Entity<Warenkorb>()
                    .HasOne<Farbe>(w => w.Farbe)
                    .WithMany(f => f.Warenkoerbe)
                    .HasForeignKey(w => w.Farbe_ID);

            // Beziehung Artikel 1 <--> n Kommentare
            modelBuilder.Entity<Kommentar>()
                .HasOne<Artikel>(k => k.Artikel)
                .WithMany(a => a.Kommentare)
                .HasForeignKey(k => k.Artikel_ID);

            // Beziehung Nutzer 1 <--> n Kommentare
            modelBuilder.Entity<Kommentar>()
                .HasOne<IdentityNutzer>(k => k.Nutzer)
                .WithMany(n => n.Kommentare)
                .HasForeignKey(k => k.Nutzer_ID);

            // Beziehung Kategorien 1 <--> n Artikel
            modelBuilder.Entity<Artikel>()
                .HasOne<Kategorie>(a => a.Kategorie)
                .WithMany(k => k.Artikel)
                .HasForeignKey(a => a.Kategorie_ID);

            // Beziehung Artikel n <--> m Farbe
                // ArtikelFarben n <--> 1 Artikel
                modelBuilder.Entity<ArtikelFarben>()
                        .HasOne<Artikel>(af => af.Artikel)
                        .WithMany(a => a.ArtikelFarben)
                        .HasForeignKey(ab => ab.Artikel_ID);
                // ArtikelFarben n <--> 1 Farbe
                modelBuilder.Entity<ArtikelFarben>()
                    .HasOne<Farbe>(af => af.Farbe)
                    .WithMany(f => f.ArtikelFarben)
                    .HasForeignKey(af => af.Farbe_ID);

            // Beziehung Bestellungen n <--> m Artikel
                // ArtikelBestellungen n <--> 1 Bestellungen
                modelBuilder.Entity<ArtikelBestellung>()
                    .HasOne<Bestellung>(ab => ab.Bestellung)
                    .WithMany(b => b.ArtikelBestellungen)
                    .HasForeignKey(ab => ab.Bestellung_ID);

                // ArtikelBestellungen n <--> 1 Artikel
                modelBuilder.Entity<ArtikelBestellung>()
                    .HasOne<Artikel>(ab => ab.Artikel)
                    .WithMany(a => a.ArtikelBestellungen)
                    .HasForeignKey(ab => ab.Artikel_ID);


            // ArtikelBestellungen n <--> 1 Farbe
            modelBuilder.Entity<ArtikelBestellung>()
                .HasOne<Farbe>(ab => ab.Farbe)
                .WithMany(f => f.ArtikelBestellungen)
                .HasForeignKey(ab => ab.Farbe_ID);

            // Beziehung Nutzer n <--> m Artikel === Warenkorb
                // Warenkorb n <--> 1 Nutzer
                modelBuilder.Entity<Warenkorb>()
                    .HasOne<IdentityNutzer>(w => w.Nutzer)
                    .WithMany(n => n.Warenkorb)
                    .HasForeignKey(w => w.Nutzer_ID);

                // Warenkorb n <--> 1 Artikel
                modelBuilder.Entity<Warenkorb>()
                    .HasOne<Artikel>(w => w.Artikel)
                    .WithMany(a => a.Warenkorb)
                    .HasForeignKey(w => w.Artikel_ID);

            // Beziehung Warenkorb n <--> m Artikel
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
    }
}