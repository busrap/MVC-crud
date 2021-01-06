namespace MVC_KuzeyYeli.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KuzeyYeliContext : DbContext
    {
        public KuzeyYeliContext() : base("name=KuzeyYeliContext")

        {

        }

        public virtual DbSet<Bolge> Bolges { get; set; }
        public virtual DbSet<Bolgeler> Bolgelers { get; set; }
        public virtual DbSet<Kategoriler> Kategorilers { get; set; }
        public virtual DbSet<MusteriDemographic> MusteriDemographics { get; set; }
        public virtual DbSet<Musteriler> Musterilers { get; set; }
        public virtual DbSet<Nakliyeciler> Nakliyecilers { get; set; }
        public virtual DbSet<Personeller> Personellers { get; set; }
        public virtual DbSet<SatisDetay> SatisDetays { get; set; }
        public virtual DbSet<Satislar> Satislars { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tedarikciler> Tedarikcilers { get; set; }
        public virtual DbSet<Urunler> Urunlers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bolge>()
                .Property(e => e.BolgeTanimi)
                .IsFixedLength();

            modelBuilder.Entity<Bolge>()
                .HasMany(e => e.Bolgelers)
                .WithRequired(e => e.Bolge)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bolgeler>()
                .Property(e => e.TerritoryTanimi)
                .IsFixedLength();

            modelBuilder.Entity<Bolgeler>()
                .HasMany(e => e.Personellers)
                .WithMany(e => e.Bolgelers)
                .Map(m => m.ToTable("PersonelBolgeler").MapLeftKey("TerritoryID").MapRightKey("PersonelID"));

            modelBuilder.Entity<MusteriDemographic>()
                .Property(e => e.MusteriTypeID)
                .IsFixedLength();

            modelBuilder.Entity<MusteriDemographic>()
                .HasMany(e => e.Musterilers)
                .WithMany(e => e.MusteriDemographics)
                .Map(m => m.ToTable("MusteriMusteriDemo").MapLeftKey("MusteriTypeID").MapRightKey("MusteriID"));

            modelBuilder.Entity<Musteriler>()
                .Property(e => e.MusteriID)
                .IsFixedLength();

            modelBuilder.Entity<Nakliyeciler>()
                .HasMany(e => e.Satislars)
                .WithOptional(e => e.Nakliyeciler)
                .HasForeignKey(e => e.ShipVia);

            modelBuilder.Entity<Personeller>()
                .HasMany(e => e.Personeller1)
                .WithOptional(e => e.Personeller2)
                .HasForeignKey(e => e.BagliCalistigiKisi);

            modelBuilder.Entity<SatisDetay>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Satislar>()
                .Property(e => e.MusteriID)
                .IsFixedLength();

            modelBuilder.Entity<Satislar>()
                .Property(e => e.NakliyeUcreti)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Satislar>()
                .HasMany(e => e.SatisDetays)
                .WithRequired(e => e.Satislar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urunler>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urunler>()
                .HasMany(e => e.SatisDetays)
                .WithRequired(e => e.Urunler)
                .WillCascadeOnDelete(false);
        }
    }
}
