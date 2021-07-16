using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WPF_Test1.Model
{
    public partial class Wypozyczalnia_PlytContext : DbContext
    {
        public Wypozyczalnia_PlytContext()
        {
        }

        public Wypozyczalnia_PlytContext(DbContextOptions<Wypozyczalnia_PlytContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SlKatNosnika> SlKatNosnikas { get; set; }
        public virtual DbSet<SlkatMuzyki> SlkatMuzykis { get; set; }
        public virtual DbSet<Slpowod> Slpowods { get; set; }
        public virtual DbSet<Tklienci> Tkliencis { get; set; }
        public virtual DbSet<Tplyty> Tplyties { get; set; }
        public virtual DbSet<TusunieciaPlyt> TusunieciaPlyts { get; set; }
        public virtual DbSet<Twypozyczenium> Twypozyczenia { get; set; }
        public SlKatNosnika nosnik { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-UK1AL1K;Integrated Security=True;Initial Catalog = Wypozyczalnia_Plyt;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<SlKatNosnika>(entity =>
            {
                entity.HasKey(e => e.NosnikId)
                    .HasName("PK__SlKat_No__4635D6D56419160C");

                entity.ToTable("SlKat_Nosnika");

                entity.Property(e => e.NosnikId).HasColumnName("NosnikID");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SlkatMuzyki>(entity =>
            {
                entity.HasKey(e => e.KategoriaId)
                    .HasName("PK__SLKat_Mu__37D210EC10A6C243");

                entity.ToTable("SLKat_Muzyki");

                entity.Property(e => e.KategoriaId).HasColumnName("KategoriaID");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Slpowod>(entity =>
            {
                entity.HasKey(e => e.PowodId)
                    .HasName("PK__SLPowod__DAEB2E081B98DC7F");

                entity.ToTable("SLPowod");

                entity.Property(e => e.PowodId).HasColumnName("PowodID");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tklienci>(entity =>
            {
                entity.HasKey(e => e.KlientId)
                    .HasName("PK__TKlienci__EA31B893E8F0BDC3");

                entity.ToTable("TKlienci");

                entity.Property(e => e.KlientId).HasColumnName("KlientID");

                entity.Property(e => e.AdrKod)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("Adr_kod");

                entity.Property(e => e.AdrMsc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Adr_msc");

                entity.Property(e => e.AdrNr)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("Adr_nr");

                entity.Property(e => e.AdrUlica)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Adr_ulica");

                entity.Property(e => e.DataDodania)
                    .HasColumnType("date")
                    .HasColumnName("Data_dodania");

                entity.Property(e => e.DataUsuniecia)
                    .HasColumnType("date")
                    .HasColumnName("Data_usuniecia");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tplyty>(entity =>
            {
                entity.HasKey(e => e.PlytaId)
                    .HasName("PK__TPlyty__67ACEA4A1AFC45A6");

                entity.ToTable("TPlyty");

                entity.Property(e => e.PlytaId).HasColumnName("PlytaID");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataWydania)
                    .HasColumnType("date")
                    .HasColumnName("Data_wydania");

                entity.Property(e => e.KategoriaId).HasColumnName("KategoriaID");

                entity.Property(e => e.NosnikId).HasColumnName("NosnikID");

                entity.Property(e => e.Tytul)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kategoria)
                    .WithMany(p => p.Tplyties)
                    .HasForeignKey(d => d.KategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPlyty__Kategori__2A4B4B5E");

                entity.HasOne(d => d.Nosnik)
                    .WithMany(p => p.Tplyties)
                    .HasForeignKey(d => d.NosnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPlyty__NosnikID__2B3F6F97");
            });

            modelBuilder.Entity<TusunieciaPlyt>(entity =>
            {
                entity.HasKey(e => e.UsunieciaId)
                    .HasName("PK__TUsuniec__1FD2965818FC926D");

                entity.ToTable("TUsuniecia_Plyt");

                entity.Property(e => e.UsunieciaId).HasColumnName("UsunieciaID");

                entity.Property(e => e.DataUsuniecia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_usuniecia");

                entity.Property(e => e.IloscPlyt).HasColumnName("Ilosc_plyt");

                entity.Property(e => e.PlytaId).HasColumnName("PlytaID");

                entity.Property(e => e.PowodId).HasColumnName("PowodID");

                entity.HasOne(d => d.Plyta)
                    .WithMany(p => p.TusunieciaPlyts)
                    .HasForeignKey(d => d.PlytaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TUsunieci__Plyta__2F10007B");

                entity.HasOne(d => d.Powod)
                    .WithMany(p => p.TusunieciaPlyts)
                    .HasForeignKey(d => d.PowodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TUsunieci__Powod__300424B4");
            });

            modelBuilder.Entity<Twypozyczenium>(entity =>
            {
                entity.HasKey(e => e.WypozyczenieId)
                    .HasName("PK__TWypozyc__547E27A0638B052E");

                entity.ToTable("TWypozyczenia");

                entity.Property(e => e.WypozyczenieId).HasColumnName("WypozyczenieID");

                entity.Property(e => e.DataWypozyczenia)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_wypozyczenia");

                entity.Property(e => e.DataZwrotu)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_zwrotu");

                entity.Property(e => e.KlientId).HasColumnName("KlientID");

                entity.Property(e => e.PlytyId).HasColumnName("PlytyID");

                entity.HasOne(d => d.Klient)
                    .WithMany(p => p.Twypozyczenia)
                    .HasForeignKey(d => d.KlientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TWypozycz__Klien__36B12243");

                entity.HasOne(d => d.Plyty)
                    .WithMany(p => p.Twypozyczenia)
                    .HasForeignKey(d => d.PlytyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TWypozycz__Plyty__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
