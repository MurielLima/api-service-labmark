using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Account.Infrastructure.EFCore.Views;
using Labmark.Domain.Modules.Client.Infrastructure.EFCore.Views;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Incubation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Report.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Views;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Views;
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
            modelBuilder.Entity<AguaDiluicao>(entity =>
            {
                entity.ToTable("AguaDiluicao", "LAB");


                entity.HasOne(d => d.fkDiluicaoAmostra)
                    .WithMany(p => p.AguaDiluicaos)
                    .HasForeignKey(d => d.fkDiluicaoAmostraId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AguaDiluicao_2");
            });

            modelBuilder.Entity<Amostra>(entity =>
            {
                entity.ToTable("Amostra", "LAB");

                entity.Property(e => e.CertificadoOficial).IsUnicode(false);

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Lacre).IsUnicode(false);

                entity.Property(e => e.Lote).IsUnicode(false);

                entity.Property(e => e.Oficio).IsUnicode(false);

                entity.Property(e => e.TAA).IsUnicode(false);

                entity.HasOne(d => d.fkSolicitacao)
                    .WithMany(p => p.Amostras)
                    .HasForeignKey(d => d.fkSolicitacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Amostra_2");
            });

            modelBuilder.Entity<ArquivoLaudo>(entity =>
            {

                entity.ToTable("ArquivoLaudo", "LAB");
                entity.Property(e => e.Caminho).IsUnicode(false);

                entity.Property(e => e.Hash).IsUnicode(false);

                entity.HasOne(d => d.fkSolicitacao)
                    .WithMany(p => p.ArquivoLaudos)
                    .HasForeignKey(d => d.fkSolicitacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ArquivoLaudo_2");
            });

            modelBuilder.Entity<ColiformesEscherichia>(entity =>
            {
                entity.ToTable("ColiformesEscherichia", "LAB");

                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.HasOne(d => d.fkEnsaiosPorAmostra)
                    .WithMany(p => p.ColiformesEscherichium)
                    .HasForeignKey(d => d.fkEnsaiosPorAmostraId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ColiformesEscherichia_2");
            });

            modelBuilder.Entity<ContagemMBLB>(entity =>
            {

                entity.ToTable("ContagemMBLB", "LAB");

                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.HasOne(d => d.fkEnsaiosPorAmostra)
                    .WithMany(p => p.ContagemMBLBs)
                    .HasForeignKey(d => d.fkEnsaiosPorAmostraId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ContagemMBLB_2");
            });

            modelBuilder.Entity<DiluicaoAmostra>(entity =>
            {
                entity.ToTable("DiluicaoAmostra", "LAB");


                entity.Property(e => e.Outros).IsUnicode(false);

                entity.HasOne(d => d.fkAmostra)
                    .WithMany(p => p.DiluicaoAmostras)
                    .HasForeignKey(d => d.fkAmostraId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DiluicaoAmostra_2");
            });

            modelBuilder.Entity<DiluicaoColiformesEscherichia>(entity =>
            {
                entity.ToTable("DiluicaoColiformesEscherichia", "LAB");


                entity.Property(e => e.Leitura).IsUnicode(false);

                entity.HasOne(d => d.fkColiformesEscherichia)
                    .WithMany(p => p.DiluicaoColiformesEscherichium)
                    .HasForeignKey(d => d.fkColiformesEscherichiaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DiluicaoColiformesEscherichia_2");
            });

            modelBuilder.Entity<Ensaio>(entity =>
            {
                entity.ToTable("Ensaio", "LAB");


                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Metodologia).IsUnicode(false);

                entity.Property(e => e.Referencia).IsUnicode(false);
            });

            modelBuilder.Entity<EnsaiosPorAmostra>(entity =>
            {

                entity.ToTable("EnsaiosPorAmostra", "LAB");

                entity.HasOne(d => d.fkAmostra)
                    .WithMany(p => p.EnsaiosPorAmostras)
                    .HasForeignKey(d => d.fkAmostraId)
                    .HasConstraintName("FK_EnsaiosPorAmostra_3");

                entity.HasOne(d => d.fkEnsaio)
                    .WithMany(p => p.EnsaiosPorAmostras)
                    .HasForeignKey(d => d.fkEnsaioId)
                    .HasConstraintName("FK_EnsaiosPorAmostra_2");
            });

            modelBuilder.Entity<Experimento>(entity =>
            {
                entity.ToTable("Experimento", "LAB");


                entity.Property(e => e.Lote).IsUnicode(false);

                entity.Property(e => e.Meio).IsUnicode(false);

                entity.HasOne(d => d.fkDiluicaoAmostra)
                    .WithMany(p => p.Experimentos)
                    .HasForeignKey(d => d.fkDiluicaoAmostraId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Experimento_2");
            });

            modelBuilder.Entity<Incubacao>(entity =>
            {

                entity.ToTable("Incubacao", "LAB");

                entity.HasOne(d => d.fkExperimento)
                    .WithMany(p => p.Incubacaos)
                    .HasForeignKey(d => d.fkExperimentoId)
                    .HasConstraintName("FK_Incubacao_2");
            });

            modelBuilder.Entity<Pergunta>(entity =>
            {
                entity.ToTable("Pergunta", "LAB");


                entity.HasOne(d => d.fkSolicitacao)
                    .WithMany(p => p.Perguntum)
                    .HasForeignKey(d => d.fkSolicitacaoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Pergunta_2");
            });

            modelBuilder.Entity<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.Pessoa>(entity =>
            {
                entity.ToTable("Pessoa", "LAB");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CEP)
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

            modelBuilder.Entity<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.PessoaFisica>(entity =>
            {
                entity.HasKey(e => e.fkPessoaId)
                    .HasName("PK__PessoaFi__F76A5F7027EF5180");

                entity.ToTable("PessoaFisica", "LAB");

                entity.HasIndex(e => e.CPF, "UQ__PessoaFi__C1F89731FE4ADCAE")
                    .IsUnique();

                entity.Property(e => e.fkPessoaId)
                    .ValueGeneratedNever()
                    .HasColumnName("fkPessoaId");

                entity.Property(e => e.CPF)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.HasOne(d => d.fkPessoa)
                    .WithOne(p => p.PessoaFisica)
                    .HasForeignKey<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.PessoaFisica>(d => d.fkPessoaId)
                    .HasConstraintName("FK_PessoaFisica_2");
            });

            modelBuilder.Entity<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.PessoaJuridica>(entity =>
            {
                entity.HasKey(e => e.fkPessoaId)
                    .HasName("PK__PessoaJu__F76A5F70FD19FCDB");

                entity.ToTable("PessoaJuridica", "LAB");

                entity.HasIndex(e => e.CNPJ, "UQ__PessoaJu__AA57D6B4275C4649")
                    .IsUnique();

                entity.Property(e => e.fkPessoaId)
                    .ValueGeneratedNever()
                    .HasColumnName("fkPessoaId");

                entity.Property(e => e.CNPJ)
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

                entity.HasOne(d => d.fkPessoa)
                    .WithOne(p => p.PessoaJuridica)
                    .HasForeignKey<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.PessoaJuridica>(d => d.fkPessoaId)
                    .HasConstraintName("FK_PessoaJuridica_2");
            });


            modelBuilder.Entity<Ponteira>(entity =>
            {
                entity.ToTable("Ponteira", "LAB");


                entity.HasOne(d => d.fkDiluicaoAmostra)
                    .WithMany(p => p.Ponteiras)
                    .HasForeignKey(d => d.fkDiluicaoAmostraId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Ponteira_2");
            });

            modelBuilder.Entity<Solicitacao>(entity =>
            {
                entity.ToTable("Solicitacao", "LAB");


                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.HasOne(d => d.fkPessoa)
                    .WithMany(p => p.Solicitacaos)
                    .HasForeignKey(d => d.fkPessoaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Solicitacao_2");
            });

            modelBuilder.Entity<VIEW_AMOSTRAINFORMACAO>(entity =>
            {
                entity.ToView("VIEW_AMOSTRAINFORMACAO", "LAB");

                entity.Property(e => e.CERTIFICADOOFICIAL).IsUnicode(false);

                entity.Property(e => e.DATAFABRICACAO).IsUnicode(false);

                entity.Property(e => e.DATAVALIDADE).IsUnicode(false);

                entity.Property(e => e.DESCRICAO).IsUnicode(false);

                entity.Property(e => e.LACRE).IsUnicode(false);

                entity.Property(e => e.LOTE).IsUnicode(false);

                entity.Property(e => e.OFICIO).IsUnicode(false);

                entity.Property(e => e.TAA).IsUnicode(false);
            });

            modelBuilder.Entity<VIEW_CLIENTEINFORMACAO>(entity =>
            {
                entity.ToView("VIEW_CLIENTEINFORMACAO", "LAB");

                entity.Property(e => e.CEP).IsUnicode(false);

                entity.Property(e => e.CPFCNPJ).IsUnicode(false);

                entity.Property(e => e.EMAIL).IsUnicode(false);

                entity.Property(e => e.ENDERECO).IsUnicode(false);

                entity.Property(e => e.NOME).IsUnicode(false);

                entity.Property(e => e.TELEFONE).IsUnicode(false);

                entity.Property(e => e.TIPOPESSOA)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VIEW_ENSAIOINFORMACAO>(entity =>
            {
                entity.ToView("VIEW_ENSAIOINFORMACAO", "LAB");

                entity.Property(e => e.ENSAIO).IsUnicode(false);

                entity.Property(e => e.METODOLOGIA).IsUnicode(false);

                entity.Property(e => e.REFERENCIA).IsUnicode(false);
            });

            modelBuilder.Entity<VIEW_LISTACHECAGEM>(entity =>
            {
                entity.ToView("VIEW_LISTACHECAGEM", "LAB");

                entity.Property(e => e.JULGAMENTO).IsUnicode(false);

                entity.Property(e => e.PERGUNTA).IsUnicode(false);

                entity.Property(e => e.RESPOSTA).IsUnicode(false);
            });

            modelBuilder.Entity<VIEW_PESSOA>(entity =>
            {
                entity.ToView("VIEW_PESSOA", "LAB");

                entity.Property(e => e.BAIRRO).IsUnicode(false);

                entity.Property(e => e.CEP).IsUnicode(false);

                entity.Property(e => e.COMPLEMENTO).IsUnicode(false);

                entity.Property(e => e.CPFCNPJ).IsUnicode(false);

                entity.Property(e => e.DDD).IsUnicode(false);

                entity.Property(e => e.EMAIL).IsUnicode(false);

                entity.Property(e => e.LOGRADOURO).IsUnicode(false);

                entity.Property(e => e.NOME).IsUnicode(false);

                entity.Property(e => e.NUMERO).IsUnicode(false);

                entity.Property(e => e.TELEFONE).IsUnicode(false);

                entity.Property(e => e.TIPOPESSOA)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
