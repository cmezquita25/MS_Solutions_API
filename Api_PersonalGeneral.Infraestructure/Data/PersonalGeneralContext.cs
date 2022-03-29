//cSpell: disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api_PersonalGeneral.Domain.Entities;

#nullable disable

namespace Api_PersonalGeneral.Infraestructure.Data
{
    public partial class PersonalGeneralContext : DbContext
    {
        public PersonalGeneralContext()
        {
        }

        public PersonalGeneralContext(DbContextOptions<PersonalGeneralContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Estudiante> Estudiantes { get; set; }
        public virtual DbSet<Inscripcion> Inscripcions { get; set; }
        public virtual DbSet<Profesor> Profesors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("pk_Admin");

                entity.ToTable("Admin");

                entity.Property(e => e.IdAdmin).HasColumnName("idAdmin");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("pk_curso");

                entity.ToTable("Curso");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Activo')");

                entity.Property(e => e.FechaCierre).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.LinkReunion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Material)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Profesor)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdProfesor)
                    .HasConstraintName("fk_IdProfCurso");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .HasName("pk_IdEstudiante");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inscripcion>(entity =>
            {
                entity.HasKey(e => e.IdInscripcion)
                    .HasName("pk_IdInscripcion");

                entity.ToTable("Inscripcion");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Inscripcions)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CursoInscripcion");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Inscripcions)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EstudianteInscripcion");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .HasName("fk_IdProfesor");

                entity.ToTable("Profesor");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.NombreCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RedesSociales)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
