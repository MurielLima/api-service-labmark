using Microsoft.EntityFrameworkCore.Migrations;

namespace Labmark.Migrations
{
    public partial class AddTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql($@"CREATE TRIGGER TRIGGER_VERIFICAR_6_3_COLIFORMESESCHERICHIA ON [LAB].[ColiformesEscherichia] INSTEAD OF
									INSERT AS BEGIN BEGIN TRY
									DECLARE @ColiformesEscherichiaId int,
										@ErrorMessage NVARCHAR(4000),
										@ErrorSeverity INT,
										@ErrorState INT;
									SET NOCOUNT ON;
									SELECT @ColiformesEscherichiaId = fkEnsaiosPorAmostraId
									FROM INSERTED 
									IF NOT EXISTS (
											SELECT 1
											FROM [LAB].[EnsaiosPorAmostra] e
												JOIN [LAB].[DiluicaoAmostra] d ON d.fkAmostraId = e.fkAmostraId
											WHERE e.Id = @ColiformesEscherichiaId
										) RAISERROR(
											'Diluição [Amostra] (6.3) ainda não foi cadastrada!',
											17,
											1
										);
										
										INSERT INTO [LAB].[ColiformesEscherichia](
										fkEnsaiosPorAmostraId,
										Ponteira_Alcada,
										BanhoMaria,
										Escherichia,
										Brilla,
										BOD,
										Fluxo_Micropipetador,
										ResultadoColiformesTotais,
										ResultadoColiformesTermotolerantes,
										Observacao,
										DataPreenchimento,
										DataResultado
										)
									SELECT INS.fkEnsaiosPorAmostraId, INS.Ponteira_Alcada, INS.BanhoMaria, INS.Escherichia, INS.Brilla, INS.BOD, INS.Fluxo_Micropipetador
									,INS.ResultadoColiformesTotais,INS.ResultadoColiformesTermotolerantes, INS.Observacao, INS.DataPreenchimento, INS.DataResultado
									FROM INSERTED INS;
									SELECT [Id]
									FROM [LAB].[ColiformesEscherichia]
									WHERE @@ROWCOUNT = 1 AND [Id] = @@IDENTITY
									END TRY BEGIN CATCH
									SELECT @ErrorMessage = ERROR_MESSAGE(),
										@ErrorSeverity = ERROR_SEVERITY(),
										@ErrorState = ERROR_STATE();
									-- return the error inside the CATCH block
									RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
									END CATCH;
									END");
			migrationBuilder.Sql($@"CREATE TRIGGER TRIGGER_VERIFICAR_6_3_CONTAGEMMBLB ON [LAB].[CONTAGEMMBLB] INSTEAD OF
									INSERT AS BEGIN BEGIN TRY
									DECLARE @ContagemMBLBId int,
										@ErrorMessage NVARCHAR(4000),
										@ErrorSeverity INT,
										@ErrorState INT;
									SET NOCOUNT ON;
									SELECT @ContagemMBLBId = fkEnsaiosPorAmostraId
									FROM INSERTED 
									IF NOT EXISTS (
											SELECT 1
											FROM [LAB].[EnsaiosPorAmostra] e
												JOIN [LAB].[DiluicaoAmostra] d ON d.fkAmostraId = e.fkAmostraId
											WHERE e.Id = @ContagemMBLBId
										) RAISERROR(
											'Diluição [Amostra] (6.3) ainda não foi cadastrada!',
											17,
											1
										);
										
										INSERT INTO [LAB].[CONTAGEMMBLB](
										fkEnsaiosPorAmostraId,
										Observacao,
										Resultado,
										DataResultado
										)
										SELECT INS.fkEnsaiosPorAmostraId, INS.Observacao, INS.Resultado, INS.DataResultado
										FROM INSERTED INS;
									SELECT [Id]
									FROM [LAB].[CONTAGEMMBLB]
									WHERE @@ROWCOUNT = 1 AND [Id] = @@IDENTITY
									END TRY BEGIN CATCH
									SELECT @ErrorMessage = ERROR_MESSAGE(),
										@ErrorSeverity = ERROR_SEVERITY(),
										@ErrorState = ERROR_STATE();
									-- return the error inside the CATCH block
									RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
									END CATCH;
									END");
			migrationBuilder.Sql($@"CREATE TRIGGER TRIGGER_CNPJ ON [LAB].[PessoaJuridica] INSTEAD OF
									INSERT,
										UPDATE AS BEGIN BEGIN TRY
									DECLARE @CNPJ varchar(20),
										@ErrorMessage NVARCHAR(4000),
										@ErrorSeverity INT,
										@ErrorState INT;
									SET NOCOUNT ON;
									SELECT @CNPJ = CNPJ
									FROM INSERTED IF([LAB].fncValida_CNPJ(@CNPJ) = 0) RAISERROR('CNPJ inválido.', 17, 1);
									
									INSERT INTO [LAB].[PessoaJuridica](
											fkPessoaId,
											CNPJ,
											InscricaoEstadual,
											ResponsavelTecnico
										)
									SELECT *
									FROM INSERTED;
									END TRY BEGIN CATCH
									SELECT [fkPessoaId]
									FROM [LAB].[PessoaJuridica]
									WHERE @@ROWCOUNT = 1 AND [fkPessoaId] = @@IDENTITY
									SELECT @ErrorMessage = ERROR_MESSAGE(),
										@ErrorSeverity = ERROR_SEVERITY(),
										@ErrorState = ERROR_STATE();
									-- return the error inside the CATCH block
									RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
									END CATCH;
									END");
			migrationBuilder.Sql($@"CREATE TRIGGER TRIGGER_CPF ON [LAB].[PessoaFisica] INSTEAD OF
									INSERT,
										UPDATE AS BEGIN BEGIN TRY
									DECLARE @CPF varchar(15),
										@ErrorMessage NVARCHAR(4000),
										@ErrorSeverity INT,
										@ErrorState INT;
									SET NOCOUNT ON;
									SELECT @CPF = CPF
									FROM INSERTED 
									IF([LAB].fncValida_CPF(@CPF) = 0) RAISERROR('CPF inválido.', 17, 1);
									
									INSERT INTO [LAB].[PessoaFisica](
											fkPessoaId,
											CPF
										)
									SELECT *
									FROM INSERTED;
									SELECT [fkPessoaId]
									FROM [LAB].[PessoaFisica]
									WHERE @@ROWCOUNT = 1 AND [fkPessoaId] = @@IDENTITY
									END TRY BEGIN CATCH
									SELECT @ErrorMessage = ERROR_MESSAGE(),
										@ErrorSeverity = ERROR_SEVERITY(),
										@ErrorState = ERROR_STATE();
									-- return the error inside the CATCH block
									RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
									END CATCH;
									END");
			migrationBuilder.Sql($@"CREATE TRIGGER TRIGGER_PESSOA ON [LAB].[Pessoa] INSTEAD OF
									INSERT,
										UPDATE AS BEGIN BEGIN TRY
									DECLARE @CEP varchar(8),
										@EMAIL varchar(100),
										@TELEFONE varchar(15),
										@ErrorMessage NVARCHAR(4000),
										@ErrorSeverity INT,
										@ErrorState INT;
									SET NOCOUNT ON;
									SELECT @CEP = CEP,
										   @EMAIL = EMAIL,
										   @TELEFONE = TELEFONE
									FROM INSERTED 
									IF(NOT @CEP IS NULL AND [LAB].fncVerifica_Cep(@CEP) = 0) RAISERROR('CEP inválido.', 17, 1);
									IF(NOT @EMAIL IS NULL AND [LAB].fncValidarEmail(@EMAIL) = 0) RAISERROR('EMAIL inválido.', 17, 1);
									IF(ISNULL(@TELEFONE,0) <> 0 AND [LAB].fncValida_Telefone(@TELEFONE) = 0) RAISERROR('TELEFONE inválido.', 17, 1);
									
									INSERT INTO [LAB].[Pessoa](
										Nome,
										Email,
										TipoPessoa,
										Logradouro,
										Numero,
										Bairro,
										CEP,
										TIPOACESSO,
    									TELEFONE,
										DDD,
										complemento
										)
									SELECT INS.NOME,INS.EMAIL,INS.TIPOPESSOA,INS.LOGRADOURO,INS.NUMERO,INS.BAIRRO,INS.CEP, INS.TIPOACESSO, INS.TELEFONE, INS.DDD, ins.complemento
									FROM INSERTED INS;
									SELECT [Id]
									FROM [LAB].[Pessoa]
									WHERE @@ROWCOUNT = 1 AND [Id] = @@IDENTITY
									END TRY BEGIN CATCH
									SELECT @ErrorMessage = ERROR_MESSAGE(),
										@ErrorSeverity = ERROR_SEVERITY(),
										@ErrorState = ERROR_STATE();
									-- return the error inside the CATCH block
									RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
									END CATCH;
									END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP TRIGGER TRIGGER_VERIFICAR_6_3_COLIFORMESESCHERICHIA");
			migrationBuilder.Sql("DROP TRIGGER TRIGGER_VERIFICAR_6_3_CONTAGEMMBLB");
			migrationBuilder.Sql("DROP TRIGGER TRIGGER_CNPJ");
			migrationBuilder.Sql("DROP TRIGGER TRIGGER_CPF");
			migrationBuilder.Sql("DROP TRIGGER TRIGGER_PESSOA");

		}
    }
}
