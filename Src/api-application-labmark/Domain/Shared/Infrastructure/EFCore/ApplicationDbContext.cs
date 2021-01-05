using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Labmark.Domain.Shared.Infrastructure.EFCore
{
    public partial class ApplicationDbContext : IdentityDbContext<Usuario, AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("LAB");
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("Pessoa", "LAB");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CEP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPessoa)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PessoaFisica>(entity =>
            {
                entity.HasKey(e => e.FkPessoaId)
                    .HasName("PK__PessoaFi__F76A5F7027EF5180");

                entity.ToTable("PessoaFisica", "LAB");

                entity.HasIndex(e => e.Cpf, "UQ__PessoaFi__C1F89731FE4ADCAE")
                    .IsUnique();

                entity.Property(e => e.FkPessoaId)
                    .ValueGeneratedNever()
                    .HasColumnName("fk_Pessoa_Id");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.HasOne(d => d.FkPessoa)
                    .WithOne(p => p.PessoaFisica)
                    .HasForeignKey<PessoaFisica>(d => d.FkPessoaId)
                    .HasConstraintName("FK_PessoaFisica_2");
            });

            modelBuilder.Entity<PessoaJuridica>(entity =>
            {
                entity.HasKey(e => e.FkPessoaId)
                    .HasName("PK__PessoaJu__F76A5F70FD19FCDB");

                entity.ToTable("PessoaJuridica", "LAB");

                entity.HasIndex(e => e.Cnpj, "UQ__PessoaJu__AA57D6B4275C4649")
                    .IsUnique();

                entity.Property(e => e.FkPessoaId)
                    .ValueGeneratedNever()
                    .HasColumnName("fk_Pessoa_Id");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.InscricaoEstadual)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsavelTecnico)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkPessoa)
                    .WithOne(p => p.PessoaJuridica)
                    .HasForeignKey<PessoaJuridica>(d => d.FkPessoaId)
                    .HasConstraintName("FK_PessoaJuridica_2");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.ToTable("Telefone", "LAB");

                entity.Property(e => e.Ddd)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DDD");

                entity.Property(e => e.FkPessoaId).HasColumnName("fk_Pessoa_Id");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkPessoa)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.FkPessoaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Telefone_2");
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
