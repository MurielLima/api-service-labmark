using Microsoft.EntityFrameworkCore.Migrations;

namespace Labmark.Migrations
{
    public partial class AddViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE VIEW [LAB].[VIEW_PESSOA]
                                    AS   
                                    SELECT P.ID IDPESSOA
                                           ,P.NOME NOME
                                           ,P.EMAIL EMAIL
                                           ,P.TipoPessoa TIPOPESSOA
                                           ,(CASE WHEN P.TipoPessoa = 'J'
                                                 THEN PJ.CNPJ
                                                 ELSE PF.CPF
                                                 END
                                            ) CPFCNPJ
                                           ,P.LOGRADOURO LOGRADOURO
                                           ,P.NUMERO NUMERO
                                           ,P.BAIRRO BAIRRO
                                           ,P.COMPLEMENTO COMPLEMENTO
                                           ,P.CEP CEP
                                           ,P.Telefone TELEFONE
                                           ,P.DDD DDD 
                                      FROM [LAB].[PESSOA] P 
                                      LEFT JOIN [LAB].[PessoaFisica] PF
                                        ON PF.fkPessoaId = P.Id
                                      LEFT JOIN [LAB].[PessoaJuridica] PJ
                                        ON PJ.fkPessoaId = P.Id");
            migrationBuilder.Sql(@$"CREATE VIEW [LAB].[VIEW_LISTACHECAGEM]
                                    AS   
                                    SELECT P.fkSolicitacaoId IDSOLICITACAO
                                            ,(CASE WHEN P.CODIGO = 1
                                                THEN 'AS AMOSTRAS ESTAVAM EMBALADAS ADEQUADAMENTE ?'
                                                WHEN P.CODIGO = 2
                                                THEN 'A TEMPERATURA ESTÁ ADEQUADA ?'
                                                WHEN P.CODIGO = 3
                                                THEN 'O VOLUME DE AMOSTRAS É SUFICIENTE ?'
                                                WHEN P.CODIGO = 4
                                                THEN 'EXISTE O PROCESSO ANALÍTICO ADEQUADO ?'
                                                ELSE 'PERGUNTA NÃO CADASTRADA'
                                                END
                                            ) PERGUNTA
                                           ,(CASE WHEN P.Resposta = 1
                                                  THEN 'SIM'
                                                  ELSE 'NÃO'
                                                  END 
                                            )RESPOSTA
                                            ,(CASE WHEN S.Julgamento = 1
                                                  THEN 'SIM'
                                                  ELSE 'NÃO'
                                                  END 
                                            )JULGAMENTO
                                      FROM [LAB].[PERGUNTA] P
                                     INNER JOIN [LAB].Solicitacao S
                                        ON S.Id = P.fkSolicitacaoId
                                     INNER JOIN [LAB].EnsaiosPorAmostra EPA
                                        ON EPA.fkEnsaioId = S.Id
                                     INNER JOIN [LAB].Amostra A
                                        ON A.Id = EPA.fkAmostraId");
            migrationBuilder.Sql($@"CREATE VIEW [LAB].[VIEW_AMOSTRAINFORMACAO]
                                    AS   
                                    SELECT  A.ID IDAMOSTRA
                                           ,S.FKPESSOAID IDPESSOA
                                           ,A.DESCRICAO DESCRICAO
                                           ,convert(varchar, A.DATAFABRICACAO,103) DATAFABRICACAO
                                           ,convert(varchar, A.DATAVALIDADE,103) DATAVALIDADE
                                           ,A.LOTE LOTE
                                           ,S.DATARECEBIMENTO DATARECEBIMENTO
                                           ,S.DATACONCLUSAO DATACONCLUSAO
                                           ,A.LACRE LACRE
                                           ,A.CERTIFICADOOFICIAL CERTIFICADOOFICIAL
                                           ,A.DATAEMISSAO DATAEMISSAO
                                           ,A.TAA TAA
                                           ,A.OFICIO OFICIO
                                           ,A.TEMPERATURA TEMPERATURA
                                      FROM [LAB].Amostra A
                                     INNER JOIN [LAB].Solicitacao S
                                        ON A.fkSolicitacaoId = S.Id");
            migrationBuilder.Sql($@"CREATE VIEW [LAB].[VIEW_ENSAIOINFORMACAO]
                                    AS   
                                    SELECT  A.ID IDAMOSTRA
                                           ,E.ID IDENSAIO
                                           ,E.DESCRICAO ENSAIO
                                           ,E.METODOLOGIA METODOLOGIA
                                           ,(CASE WHEN ISNULL(CE.ResultadoColiformesTermotolerantes,'')<>''
                                                  THEN CE.ResultadoColiformesTermotolerantes
                                                  WHEN ISNULL(CE.ResultadoColiformesTotais ,'')<>''
                                                  THEN CE.ResultadoColiformesTotais 
                                                  ELSE  (SELECT SUM(CM.RESULTADO)/2 FROM [LAB].ContagemMBLB CM WHERE CM.fkEnsaiosPorAmostraId = EPA.Id) 
                                                  END
                                            ) AS RESULTADO
                                           ,E.REFERENCIA REFERENCIA
                                      FROM [LAB].Amostra A
                                     INNER JOIN [LAB].EnsaiosPorAmostra EPA
                                        ON EPA.fkAmostraId = A.Id
                                     INNER JOIN [LAB].Ensaio E
                                        ON E.Id = EPA.fkEnsaioId
                                     LEFT JOIN [LAB].ContagemMBLB CM
                                       ON CM.fkEnsaiosPorAmostraId = EPA.Id
                                     LEFT JOIN [LAB].ColiformesEscherichia CE
                                       ON CE.fkEnsaiosPorAmostraId = EPA.Id");
            migrationBuilder.Sql($@"CREATE VIEW [LAB].[VIEW_CLIENTEINFORMACAO]
                                    AS   
                                    SELECT P.IDPESSOA IDPESSOA
                                        ,P.NOME NOME
                                        ,P.CPFCNPJ CPFCNPJ
                                        ,P.TipoPessoa TIPOPESSOA
                                        ,(P.LOGRADOURO + ', '+ CAST(P.NUMERO AS VARCHAR) + ', ' +P.BAIRRO) ENDERECO
                                        ,P.CEP CEP
                                        ,('('+CAST(P.DDD AS VARCHAR)+')'+' '+ CAST(P.TELEFONE AS VARCHAR)) TELEFONE
                                        ,P.EMAIL EMAIL   
                                    FROM [LAB].[VIEW_PESSOA] P ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [LAB].[VIEW_PESSOA]");
            migrationBuilder.Sql("DROP VIEW [LAB].[VIEW_LISTACHECAGEM]");
            migrationBuilder.Sql("DROP VIEW [LAB].[VIEW_AMOSTRAINFORMACAO]");
            migrationBuilder.Sql("DROP VIEW [LAB].[VIEW_CLIENTEINFORMACAO]");
        }
    }
}
