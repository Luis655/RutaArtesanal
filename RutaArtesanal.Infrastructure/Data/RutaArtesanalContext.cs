using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RutaArtesanal.Api.RutaArtesanal.Domain.Entities;

#nullable disable

namespace RutaArtesanal.Infrastructure.Context
{
    public partial class RutaArtesanalContext : DbContext
    {
        public RutaArtesanalContext()
        {
        }

        public RutaArtesanalContext(DbContextOptions<RutaArtesanalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artesanium> Artesania { get; set; }
        public virtual DbSet<Artesano> Artesanos { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<Taller> Tallers { get; set; }
        public virtual DbSet<Viajero> Viajeros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-QFEKVLB1\\FERNS;Initial Catalog=RutaArtesanal;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Artesanium>(entity =>
            {
                entity.HasKey(e => e.Idartesania)
                    .HasName("PK_IDARTESANIA");

                entity.Property(e => e.Idartesania).HasColumnName("IDARTESANIA");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Foto)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("FOTO");

                entity.Property(e => e.Material)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MATERIAL");

                entity.Property(e => e.Nombreartesania)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREARTESANIA");
            });

            modelBuilder.Entity<Artesano>(entity =>
            {
                entity.HasKey(e => e.Idartesano)
                    .HasName("PK_IDARTESANO");

                entity.ToTable("Artesano");

                entity.Property(e => e.Idartesano).HasColumnName("IDARTESANO");

                entity.Property(e => e.Apellidom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOM");

                entity.Property(e => e.Apellidop)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOP");

                entity.Property(e => e.Asociacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASOCIACION");

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CELULAR");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASEÑA");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnType("date")
                    .HasColumnName("FECHANACIMIENTO");

                entity.Property(e => e.Genero)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GENERO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Statusartesano)
                    .HasColumnType("date")
                    .HasColumnName("STATUSARTESANO");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Idmenu)
                    .HasName("PK_IDMENU");

                entity.ToTable("Menu");

                entity.Property(e => e.Idmenu).HasColumnName("IDMENU");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("FOTO");

                entity.Property(e => e.Nombreplatillo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREPLATILLO");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TIPO");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.Idrestaurante)
                    .HasName("PK_IDRESTAURANTE");

                entity.ToTable("Restaurante");

                entity.Property(e => e.Idrestaurante).HasColumnName("IDRESTAURANTE");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LATITUD");

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUD");

                entity.Property(e => e.Menurestaurante).HasColumnName("MENURESTAURANTE");

                entity.Property(e => e.Nombrerestaurante)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRERESTAURANTE");

                entity.HasOne(d => d.MenurestauranteNavigation)
                    .WithMany(p => p.Restaurantes)
                    .HasForeignKey(d => d.Menurestaurante)
                    .HasConstraintName("FK_MENURESTAURANTE");
            });

            modelBuilder.Entity<Taller>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Taller");

                entity.Property(e => e.Datosartesano).HasColumnName("DATOSARTESANO");

                entity.Property(e => e.Idtaller)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDTALLER");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LATITUD");

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LONGITUD");

                entity.Property(e => e.Nombretaller)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRETALLER");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.HasOne(d => d.DatosartesanoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Datosartesano)
                    .HasConstraintName("FK_DATOSARTESANO");
            });

            modelBuilder.Entity<Viajero>(entity =>
            {
                entity.HasKey(e => e.Idviajero)
                    .HasName("PK_IDVIAJERO");

                entity.ToTable("Viajero");

                entity.Property(e => e.Idviajero).HasColumnName("IDVIAJERO");

                entity.Property(e => e.Apellidomat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOMAT");

                entity.Property(e => e.Apellidopat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOPAT");

                entity.Property(e => e.Celular)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CELULAR");

                entity.Property(e => e.Contraseñaviajero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASEÑAVIAJERO");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fechanaci)
                    .HasColumnType("date")
                    .HasColumnName("FECHANACI");

                entity.Property(e => e.Genero)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("GENERO");

                entity.Property(e => e.Lat)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LAT");

                entity.Property(e => e.Long)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LONG");

                entity.Property(e => e.Nombrebiajero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREBIAJERO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
