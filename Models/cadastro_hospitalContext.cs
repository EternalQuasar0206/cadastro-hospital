using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace cadastro_hospital.Models
{
    public partial class cadastro_hospitalContext : DbContext
    {
        public cadastro_hospitalContext()
        {
        }

        public cadastro_hospitalContext(DbContextOptions<cadastro_hospitalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exame> Exames { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<TipoExame> TipoExames { get; set; }
        public virtual DbSet<Consulta> Consultas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=cadastro_hospital;User Id=postgres;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Portuguese_Brazil.1252");

            modelBuilder.Entity<Exame>(entity =>
            {
                entity.ToTable("exames");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("descricao");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.TipoexameId).HasColumnName("tipoexame_id");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("pacientes");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nascimento)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("nascimento");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(1)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("telefone");
            });

            modelBuilder.Entity<TipoExame>(entity =>
            {
                entity.ToTable("tipo_exame");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("descricao");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.ToTable("consultar");

                entity.Property(e => e.Paciente)
                    .IsRequired()
                    .HasColumnName("paciente");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Exame)
                    .IsRequired()
                    .HasColumnName("exame");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.Protocolo)
                    .IsRequired()
                    .HasColumnName("protocolo"); 
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
