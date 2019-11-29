using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using it_shop_app.Models;
using it_shop_app.Areas.Identity.Data;

namespace it_shop_app.Data 
{
    public class ShopContext : IdentityDbContext<IdentityNutzer>
    {
        public ShopContext (DbContextOptions<ShopContext> options) 
            : base(options) 
        { }

        public DbSet<Merkmal> Merkmale { get; set; }
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Liste> Listen { get; set; }
        public DbSet<Kategorie> Kategorien { get; set; }
        public DbSet<Bewertung> Bewertungen { get; set; }
        public DbSet<Kommentar> Kommentare { get; set; }
        // Zuordnungstabellen
        public DbSet<ArtikelBestellungen> ArtikelBestellungen { get; set; }
        public DbSet<Warenkorb> Warenkoerbe { get; set; }
        public DbSet<ListenArtikel> ListenArtikel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {     
            base.OnModelCreating(modelBuilder);

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
                    .HasOne<IdentityNutzer>(w => w.Nutzer)
                    .WithMany(n => n.Warenkorb)
                    .HasForeignKey(w => w.Nutzer_ID);

                // Warenkorb n <--> 1 Artikel
                modelBuilder.Entity<Warenkorb>()
                    .HasOne<Artikel>(w => w.Artikel)
                    .WithMany(a => a.Warenkorb)
                    .HasForeignKey(w => w.Artikel_ID);

            // Beziehung Nutzer 1 <--> n Listen
            modelBuilder.Entity<Liste>()
                .HasOne<IdentityNutzer>(l => l.Nutzer)
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

            // Beziehung Artikel 1 <--> n Bewertungen
            modelBuilder.Entity<Bewertung>()
                .HasOne<Artikel>(b => b.Artikel)
                .WithMany(a => a.Bewertungen)
                .HasForeignKey(k => k.Artikel_ID);

            // Beziehung Nutzer 1 <--> n Bewertungen
            modelBuilder.Entity<Bewertung>()
                .HasOne<IdentityNutzer>(b => b.Nutzer)
                .WithMany(n => n.Bewertungen)
                .HasForeignKey(b => b.Nutzer_ID);

            // Beziehung Kategorien 1 <--> n Artikel
            modelBuilder.Entity<Artikel>()
                .HasOne<Kategorie>(a => a.Kategorie)
                .WithMany(k => k.Artikel)
                .HasForeignKey(a => a.Kategorie_ID);
        }
    }
}