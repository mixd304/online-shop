﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using it_shop_app.Data;

namespace it_shop_app.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("it_shop_app.Areas.Identity.Data.IdentityNutzer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Geburtsdatum")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hausnummer")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("Ort")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Plz")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Strasse")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("it_shop_app.Models.Artikel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Beschreibung")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preis")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("ID");

                    b.ToTable("Artikel");
                });

            modelBuilder.Entity("it_shop_app.Models.ArtikelBestellungen", b =>
                {
                    b.Property<int>("Artikel_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bestellung_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Artikel_ID", "Bestellung_ID");

                    b.HasIndex("Bestellung_ID");

                    b.ToTable("ArtikelBestellungen");
                });

            modelBuilder.Entity("it_shop_app.Models.Bestellung", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Bestelldatum")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Gesamtpreis")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Nutzer_ID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Nutzer_ID");

                    b.ToTable("Bestellungen");
                });

            modelBuilder.Entity("it_shop_app.Models.Liste", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nutzer_ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("bezeichnung")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Nutzer_ID");

                    b.ToTable("Listen");
                });

            modelBuilder.Entity("it_shop_app.Models.ListenArtikel", b =>
                {
                    b.Property<int>("Liste_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Artikel_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Liste_ID", "Artikel_ID");

                    b.HasIndex("Artikel_ID");

                    b.ToTable("ListenArtikel");
                });

            modelBuilder.Entity("it_shop_app.Models.Merkmal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Artikel_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bezeichnung")
                        .HasColumnType("TEXT");

                    b.Property<string>("Wert")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Artikel_ID");

                    b.ToTable("Merkmale");
                });

            modelBuilder.Entity("it_shop_app.Models.Warenkorb", b =>
                {
                    b.Property<string>("Nutzer_ID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Artikel_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Nutzer_ID", "Artikel_ID");

                    b.HasIndex("Artikel_ID");

                    b.ToTable("Warenkoerbe");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("it_shop_app.Areas.Identity.Data.IdentityNutzer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("it_shop_app.Areas.Identity.Data.IdentityNutzer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("it_shop_app.Areas.Identity.Data.IdentityNutzer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("it_shop_app.Areas.Identity.Data.IdentityNutzer", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("it_shop_app.Models.ArtikelBestellungen", b =>
                {
                    b.HasOne("it_shop_app.Models.Artikel", "Artikel")
                        .WithMany("ArtikelBestellungen")
                        .HasForeignKey("Artikel_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("it_shop_app.Models.Bestellung", "Bestellung")
                        .WithMany("ArtikelBestellungen")
                        .HasForeignKey("Bestellung_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("it_shop_app.Models.Bestellung", b =>
                {
                    b.HasOne("it_shop_app.Areas.Identity.Data.IdentityNutzer", "Kaeufer")
                        .WithMany("Bestellungen")
                        .HasForeignKey("Nutzer_ID");
                });

            modelBuilder.Entity("it_shop_app.Models.Liste", b =>
                {
                    b.HasOne("it_shop_app.Areas.Identity.Data.IdentityNutzer", "Nutzer")
                        .WithMany("Listen")
                        .HasForeignKey("Nutzer_ID");
                });

            modelBuilder.Entity("it_shop_app.Models.ListenArtikel", b =>
                {
                    b.HasOne("it_shop_app.Models.Artikel", "Artikel")
                        .WithMany("ListenArtikel")
                        .HasForeignKey("Artikel_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("it_shop_app.Models.Liste", "Liste")
                        .WithMany("ListenArtikel")
                        .HasForeignKey("Liste_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("it_shop_app.Models.Merkmal", b =>
                {
                    b.HasOne("it_shop_app.Models.Artikel", "Artikel")
                        .WithMany("Merkmale")
                        .HasForeignKey("Artikel_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("it_shop_app.Models.Warenkorb", b =>
                {
                    b.HasOne("it_shop_app.Models.Artikel", "Artikel")
                        .WithMany("Warenkorb")
                        .HasForeignKey("Artikel_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("it_shop_app.Areas.Identity.Data.IdentityNutzer", "Nutzer")
                        .WithMany("Warenkorb")
                        .HasForeignKey("Nutzer_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
