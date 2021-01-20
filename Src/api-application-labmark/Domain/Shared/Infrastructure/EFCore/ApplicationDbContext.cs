using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Labmark.Domain.Shared.Infrastructure.EFCore
{
    public partial class ApplicationDbContext : IdentityDbContext<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.Usuario, Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.AppRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("LAB");
            modelBuilder.Entity<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.Pessoa>(entity =>
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

            modelBuilder.Entity<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.PessoaFisica>(entity =>
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
                    .HasForeignKey<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.PessoaFisica>(d => d.FkPessoaId)
                    .HasConstraintName("FK_PessoaFisica_2");
            });

            modelBuilder.Entity<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.PessoaJuridica>(entity =>
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
                    .HasForeignKey<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.PessoaJuridica>(d => d.FkPessoaId)
                    .HasConstraintName("FK_PessoaJuridica_2");
            });

            modelBuilder.Entity<Labmark.Domain.Modules.Account.Infrastructure.EFCore.Entities.Telefone>(entity =>
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
            modelBuilder.Entity<AguaDiluicao>(entity =>
            {
                entity.HasOne(d => d.fk_DiluicaoAmostra)
                    .WithMany(p => p.AguaDiluicaos)
                    .HasForeignKey(d => d.fk_DiluicaoAmostra_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_AguaDiluicao_2");
            });

            modelBuilder.Entity<Amostra>(entity =>
            {
                entity.Property(e => e.CertificadoOficial).IsUnicode(false);

                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Lacre).IsUnicode(false);

                entity.Property(e => e.Lote).IsUnicode(false);

                entity.Property(e => e.Oficio).IsUnicode(false);

                entity.Property(e => e.TAA).IsUnicode(false);

                entity.HasOne(d => d.fk_Pessoa)
                    .WithMany(p => p.Amostras)
                    .HasForeignKey(d => d.fk_Pessoa_Id)
                    .HasConstraintName("FK_Amostra_3");

                entity.HasOne(d => d.fk_Solicitacao)
                    .WithMany(p => p.Amostras)
                    .HasForeignKey(d => d.fk_Solicitacao_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Amostra_2");
            });

            modelBuilder.Entity<ArquivoLaudo>(entity =>
            {
                entity.Property(e => e.Caminho).IsUnicode(false);

                entity.Property(e => e.Hash).IsUnicode(false);

                entity.HasOne(d => d.fk_Solicitacao)
                    .WithMany(p => p.ArquivoLaudos)
                    .HasForeignKey(d => d.fk_Solicitacao_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ArquivoLaudo_2");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.fk_Pessoa_Id })
                    .HasName("PK__AspNetUs__2D6249F05E11148C");

                entity.HasOne(d => d.fk_Pessoa)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.fk_Pessoa_Id)
                    .HasConstraintName("FK_AspNetUsers_2");
            });

            modelBuilder.Entity<ColiformesEscherichium>(entity =>
            {
                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.HasOne(d => d.fk_EnsaiosPorAmostra)
                    .WithMany(p => p.ColiformesEscherichia)
                    .HasForeignKey(d => d.fk_EnsaiosPorAmostra_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ColiformesEscherichia_2");
            });

            modelBuilder.Entity<ContagemMBLB>(entity =>
            {
                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.HasOne(d => d.fk_EnsaiosPorAmostra)
                    .WithMany(p => p.ContagemMBLBs)
                    .HasForeignKey(d => d.fk_EnsaiosPorAmostra_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ContagemMBLB_2");
            });

            modelBuilder.Entity<Diluicao>(entity =>
            {
                entity.Property(e => e.Lote).IsUnicode(false);

                entity.HasOne(d => d.fk_Leitura)
                    .WithMany(p => p.Diluicaos)
                    .HasForeignKey(d => d.fk_Leitura_Id)
                    .HasConstraintName("FK_Diluicao_2");
            });

            modelBuilder.Entity<DiluicaoAmostra>(entity =>
            {
                entity.Property(e => e.Outros).IsUnicode(false);

                entity.HasOne(d => d.fk_Amostra)
                    .WithMany(p => p.DiluicaoAmostras)
                    .HasForeignKey(d => d.fk_Amostra_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_DiluicaoAmostra_2");
            });

            modelBuilder.Entity<DiluicaoParaColiformesEscherichium>(entity =>
            {
                entity.HasOne(d => d.fk_ColiformesEscherichia)
                    .WithMany()
                    .HasForeignKey(d => d.fk_ColiformesEscherichia_Id)
                    .HasConstraintName("FK_DiluicaoParaColiformesEscherichia_1");

                entity.HasOne(d => d.fk_Leitura)
                    .WithMany()
                    .HasForeignKey(d => d.fk_Leitura_Id)
                    .HasConstraintName("FK_DiluicaoParaColiformesEscherichia_2");
            });

            modelBuilder.Entity<DiluicaoParaContagemMBLB>(entity =>
            {
                entity.HasOne(d => d.fk_ContagemMBLB)
                    .WithMany()
                    .HasForeignKey(d => d.fk_ContagemMBLB_Id)
                    .HasConstraintName("FK_DiluicaoParaContagemMBLB_1");

                entity.HasOne(d => d.fk_Leitura)
                    .WithMany()
                    .HasForeignKey(d => d.fk_Leitura_Id)
                    .HasConstraintName("FK_DiluicaoParaContagemMBLB_2");
            });

            modelBuilder.Entity<DiluicaoPorExperimento>(entity =>
            {
                entity.HasOne(d => d.fk_Diluicao)
                    .WithMany()
                    .HasForeignKey(d => d.fk_Diluicao_Id)
                    .HasConstraintName("FK_Contem_2");

                entity.HasOne(d => d.fk_Experimento)
                    .WithMany()
                    .HasForeignKey(d => d.fk_Experimento_Id)
                    .HasConstraintName("FK_Contem_1");
            });

            modelBuilder.Entity<Ensaio>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);

                entity.Property(e => e.Metodologia).IsUnicode(false);

                entity.Property(e => e.Referencia).IsUnicode(false);
            });

            modelBuilder.Entity<EnsaiosPorAmostra>(entity =>
            {
                entity.HasOne(d => d.fk_Amostra)
                    .WithMany(p => p.EnsaiosPorAmostras)
                    .HasForeignKey(d => d.fk_Amostra_Id)
                    .HasConstraintName("FK_EnsaiosPorAmostra_3");

                entity.HasOne(d => d.fk_Ensaio)
                    .WithMany(p => p.EnsaiosPorAmostras)
                    .HasForeignKey(d => d.fk_Ensaio_Id)
                    .HasConstraintName("FK_EnsaiosPorAmostra_2");
            });

            modelBuilder.Entity<Experimento>(entity =>
            {
                entity.Property(e => e.Lote).IsUnicode(false);

                entity.Property(e => e.Meio).IsUnicode(false);

                entity.HasOne(d => d.fk_DiluicaoAmostra)
                    .WithMany(p => p.Experimentos)
                    .HasForeignKey(d => d.fk_DiluicaoAmostra_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Experimento_2");
            });

            modelBuilder.Entity<Incubacao>(entity =>
            {
                entity.HasOne(d => d.fk_Experimento)
                    .WithMany(p => p.Incubacaos)
                    .HasForeignKey(d => d.fk_Experimento_Id)
                    .HasConstraintName("FK_Incubacao_2");
            });

            modelBuilder.Entity<Perguntum>(entity =>
            {
                entity.HasOne(d => d.fk_Solicitacao)
                    .WithMany(p => p.Pergunta)
                    .HasForeignKey(d => d.fk_Solicitacao_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Pergunta_2");
            });

            modelBuilder.Entity<Ponteira>(entity =>
            {
                entity.HasOne(d => d.fk_DiluicaoAmostra)
                    .WithMany(p => p.Ponteiras)
                    .HasForeignKey(d => d.fk_DiluicaoAmostra_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Ponteira_2");
            });

            modelBuilder.Entity<Solicitacao>(entity =>
            {
                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.HasOne(d => d.fk_Pessoa)
                    .WithMany(p => p.Solicitacaos)
                    .HasForeignKey(d => d.fk_Pessoa_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Solicitacao_2");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.Property(e => e.DDD).IsUnicode(false);

                entity.Property(e => e.Numero).IsUnicode(false);

                entity.HasOne(d => d.fk_Pessoa)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.fk_Pessoa_Id)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Telefone_2");
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

                entity.Property(e => e.TIPOPESSOA).IsUnicode(false);
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

                entity.Property(e => e.CPFCNPJ).IsUnicode(false);

                entity.Property(e => e.EMAIL).IsUnicode(false);

                entity.Property(e => e.LOGRADOURO).IsUnicode(false);

                entity.Property(e => e.NOME).IsUnicode(false);

                entity.Property(e => e.TIPOPESSOA).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
}
