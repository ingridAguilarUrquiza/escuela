using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace escuelaPrueba.Models
{
    public partial class escuelaContext : DbContext
    {
        public escuelaContext()
        {
        }

        public escuelaContext(DbContextOptions<escuelaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<Alumnosalon> Alumnosalon { get; set; }
        public virtual DbSet<Salon> Salon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;database=escuela;user=root;password=root;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("alumno");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidoMaterno)
                    .HasColumnName("apellidoMaterno")
                    .HasMaxLength(200);

                entity.Property(e => e.ApellidoPaterno)
                    .HasColumnName("apellidoPaterno")
                    .HasMaxLength(200);

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Alumnosalon>(entity =>
            {
                entity.ToTable("alumnosalon");

                entity.HasIndex(e => e.AlumnoId)
                    .HasName("alumno_id_idx");

                entity.HasIndex(e => e.SalonId)
                    .HasName("salon_id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.AlumnoId).HasColumnName("alumno_id");

                entity.Property(e => e.SalonId).HasColumnName("salon_id");

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.Alumnosalon)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("alumno_id");

                entity.HasOne(d => d.Salon)
                    .WithMany(p => p.Alumnosalon)
                    .HasForeignKey(d => d.SalonId)
                    .HasConstraintName("salon_id");
            });

            modelBuilder.Entity<Salon>(entity =>
            {
                entity.ToTable("salon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
