using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaestroMunicipos.Model
{

    public class MaestroMunicipiosContext : DbContext
    {
        public MaestroMunicipiosContext(DbContextOptions<MaestroMunicipiosContext> options)
            : base(options)
        { }

        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Pais> Pais { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.DepartamentoId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Pais)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.PaisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departamento_Pais");
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.Property(e => e.MunicipioId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.DepartamentoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_Departamento");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.Property(e => e.PaisId).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });
        }
    }
}