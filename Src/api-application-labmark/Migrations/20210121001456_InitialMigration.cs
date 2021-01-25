using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labmark.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "LAB");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ensaio",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Metodologia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Referencia = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensaio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leitura",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Leitura = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leitura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TipoPessoa = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Numero = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    Bairro = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    CEP = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TipoAcesso = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "LAB",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diluicao",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkLeituraId = table.Column<int>(type: "int", nullable: true),
                    Diluicao = table.Column<double>(type: "float", nullable: false),
                    Lote = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diluicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diluicao_2",
                        column: x => x.fkLeituraId,
                        principalSchema: "LAB",
                        principalTable: "Leitura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkPessoaId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Pessoa_fkPessoaId",
                        column: x => x.fkPessoaId,
                        principalSchema: "LAB",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaFisica",
                schema: "LAB",
                columns: table => new
                {
                    fkPessoaId = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PessoaFi__F76A5F7027EF5180", x => x.fkPessoaId);
                    table.ForeignKey(
                        name: "FK_PessoaFisica_2",
                        column: x => x.fkPessoaId,
                        principalSchema: "LAB",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PessoaJuridica",
                schema: "LAB",
                columns: table => new
                {
                    fkPessoaId = table.Column<int>(type: "int", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    ResponsavelTecnico = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PessoaJu__F76A5F70FD19FCDB", x => x.fkPessoaId);
                    table.ForeignKey(
                        name: "FK_PessoaJuridica_2",
                        column: x => x.fkPessoaId,
                        principalSchema: "LAB",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkPessoaId = table.Column<int>(type: "int", nullable: true),
                    Julgamento = table.Column<bool>(type: "bit", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DataRecebimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitacao_2",
                        column: x => x.fkPessoaId,
                        principalSchema: "LAB",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkPessoaId = table.Column<int>(type: "int", nullable: true),
                    DDD = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    Numero = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_2",
                        column: x => x.fkPessoaId,
                        principalSchema: "LAB",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "LAB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "LAB",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "LAB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "LAB",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "LAB",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "LAB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "LAB",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "LAB",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amostra",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkSolicitacaoId = table.Column<int>(type: "int", nullable: true),
                    fkPessoaId = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: true),
                    Lote = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DataValidade = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataFabricacao = table.Column<DateTime>(type: "datetime", nullable: true),
                    Lacre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DataColeta = table.Column<DateTime>(type: "datetime", nullable: true),
                    TAA = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    DataEmissao = table.Column<DateTime>(type: "datetime", nullable: true),
                    CertificadoOficial = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: true),
                    Oficio = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amostra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amostra_2",
                        column: x => x.fkSolicitacaoId,
                        principalSchema: "LAB",
                        principalTable: "Solicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amostra_3",
                        column: x => x.fkPessoaId,
                        principalSchema: "LAB",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArquivoLaudo",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkSolicitacaoId = table.Column<int>(type: "int", nullable: true),
                    Hash = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    DataGerado = table.Column<DateTime>(type: "datetime", nullable: true),
                    Caminho = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquivoLaudo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArquivoLaudo_2",
                        column: x => x.fkSolicitacaoId,
                        principalSchema: "LAB",
                        principalTable: "Solicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pergunta",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkSolicitacaoId = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Resposta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pergunta_2",
                        column: x => x.fkSolicitacaoId,
                        principalSchema: "LAB",
                        principalTable: "Solicitacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiluicaoAmostra",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkAmostraId = table.Column<int>(type: "int", nullable: true),
                    Micropipeta = table.Column<int>(type: "int", nullable: true),
                    Pipeta = table.Column<int>(type: "int", nullable: true),
                    Homogeneizador = table.Column<int>(type: "int", nullable: true),
                    Agitador = table.Column<int>(type: "int", nullable: true),
                    Placa = table.Column<double>(type: "float", nullable: true),
                    Local = table.Column<int>(type: "int", nullable: true),
                    Outros = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiluicaoAmostra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiluicaoAmostra_2",
                        column: x => x.fkAmostraId,
                        principalSchema: "LAB",
                        principalTable: "Amostra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnsaiosPorAmostra",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEnsaioId = table.Column<int>(type: "int", nullable: true),
                    fkAmostraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsaiosPorAmostra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnsaiosPorAmostra_2",
                        column: x => x.fkEnsaioId,
                        principalSchema: "LAB",
                        principalTable: "Ensaio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnsaiosPorAmostra_3",
                        column: x => x.fkAmostraId,
                        principalSchema: "LAB",
                        principalTable: "Amostra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AguaDiluicao",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkDiluicaoAmostraId = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AguaDiluicao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AguaDiluicao_2",
                        column: x => x.fkDiluicaoAmostraId,
                        principalSchema: "LAB",
                        principalTable: "DiluicaoAmostra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experimento",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkDiluicaoAmostraId = table.Column<int>(type: "int", nullable: true),
                    Meio = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Lote = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    BOD = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experimento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experimento_2",
                        column: x => x.fkDiluicaoAmostraId,
                        principalSchema: "LAB",
                        principalTable: "DiluicaoAmostra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ponteira",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkDiluicaoAmostraId = table.Column<int>(type: "int", nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponteira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ponteira_2",
                        column: x => x.fkDiluicaoAmostraId,
                        principalSchema: "LAB",
                        principalTable: "DiluicaoAmostra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColiformesEscherichia",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEnsaiosPorAmostraId = table.Column<int>(type: "int", nullable: true),
                    Ponteira_Alcada = table.Column<int>(type: "int", nullable: true),
                    BanhoMaria = table.Column<int>(type: "int", nullable: true),
                    Escherichia = table.Column<double>(type: "float", nullable: true),
                    Brilla = table.Column<double>(type: "float", nullable: true),
                    BOD = table.Column<int>(type: "int", nullable: true),
                    Fluxo_Micropipetador = table.Column<int>(type: "int", nullable: true),
                    ColiformesTotais = table.Column<int>(type: "int", nullable: true),
                    ColiformesTermotolerantes = table.Column<int>(type: "int", nullable: true),
                    Resultado = table.Column<double>(type: "float", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DataPreenchimento = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataResultado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColiformesEscherichia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColiformesEscherichia_2",
                        column: x => x.fkEnsaiosPorAmostraId,
                        principalSchema: "LAB",
                        principalTable: "EnsaiosPorAmostra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContagemMBLB",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEnsaiosPorAmostraId = table.Column<int>(type: "int", nullable: true),
                    Resultado = table.Column<double>(type: "float", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DataResultado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContagemMBLB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContagemMBLB_2",
                        column: x => x.fkEnsaiosPorAmostraId,
                        principalSchema: "LAB",
                        principalTable: "EnsaiosPorAmostra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiluicaoPorExperimento",
                schema: "LAB",
                columns: table => new
                {
                    fkExperimentoId = table.Column<int>(type: "int", nullable: true),
                    fkDiluicaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Contem_1",
                        column: x => x.fkExperimentoId,
                        principalSchema: "LAB",
                        principalTable: "Experimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contem_2",
                        column: x => x.fkDiluicaoId,
                        principalSchema: "LAB",
                        principalTable: "Diluicao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incubacao",
                schema: "LAB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkExperimentoId = table.Column<int>(type: "int", nullable: true),
                    TemperaturaIncubacao = table.Column<int>(type: "int", nullable: true),
                    MinutosIncubacao = table.Column<int>(type: "int", nullable: true),
                    DataAbertura = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataFinalizacao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incubacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incubacao_2",
                        column: x => x.fkExperimentoId,
                        principalSchema: "LAB",
                        principalTable: "Experimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiluicaoParaColiformesEscherichia",
                schema: "LAB",
                columns: table => new
                {
                    fkColiformesEscherichiaId = table.Column<int>(type: "int", nullable: true),
                    fkLeituraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_DiluicaoParaColiformesEscherichia_1",
                        column: x => x.fkColiformesEscherichiaId,
                        principalSchema: "LAB",
                        principalTable: "ColiformesEscherichia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiluicaoParaColiformesEscherichia_2",
                        column: x => x.fkLeituraId,
                        principalSchema: "LAB",
                        principalTable: "Leitura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DiluicaoParaContagemMBLB",
                schema: "LAB",
                columns: table => new
                {
                    fkContagemMBLBId = table.Column<int>(type: "int", nullable: true),
                    fkLeituraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_DiluicaoParaContagemMBLB_1",
                        column: x => x.fkContagemMBLBId,
                        principalSchema: "LAB",
                        principalTable: "ContagemMBLB",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiluicaoParaContagemMBLB_2",
                        column: x => x.fkLeituraId,
                        principalSchema: "LAB",
                        principalTable: "Leitura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AguaDiluicao_fkDiluicaoAmostraId",
                schema: "LAB",
                table: "AguaDiluicao",
                column: "fkDiluicaoAmostraId");

            migrationBuilder.CreateIndex(
                name: "IX_Amostra_fkPessoaId",
                schema: "LAB",
                table: "Amostra",
                column: "fkPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Amostra_fkSolicitacaoId",
                schema: "LAB",
                table: "Amostra",
                column: "fkSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ArquivoLaudo_fkSolicitacaoId",
                schema: "LAB",
                table: "ArquivoLaudo",
                column: "fkSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "LAB",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "LAB",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "LAB",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "LAB",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "LAB",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "LAB",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_fkPessoaId",
                schema: "LAB",
                table: "AspNetUsers",
                column: "fkPessoaId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "LAB",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ColiformesEscherichia_fkEnsaiosPorAmostraId",
                schema: "LAB",
                table: "ColiformesEscherichia",
                column: "fkEnsaiosPorAmostraId");

            migrationBuilder.CreateIndex(
                name: "IX_ContagemMBLB_fkEnsaiosPorAmostraId",
                schema: "LAB",
                table: "ContagemMBLB",
                column: "fkEnsaiosPorAmostraId");

            migrationBuilder.CreateIndex(
                name: "IX_Diluicao_fkLeituraId",
                schema: "LAB",
                table: "Diluicao",
                column: "fkLeituraId");

            migrationBuilder.CreateIndex(
                name: "IX_DiluicaoAmostra_fkAmostraId",
                schema: "LAB",
                table: "DiluicaoAmostra",
                column: "fkAmostraId");

            migrationBuilder.CreateIndex(
                name: "IX_DiluicaoParaColiformesEscherichia_fkColiformesEscherichiaId",
                schema: "LAB",
                table: "DiluicaoParaColiformesEscherichia",
                column: "fkColiformesEscherichiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DiluicaoParaColiformesEscherichia_fkLeituraId",
                schema: "LAB",
                table: "DiluicaoParaColiformesEscherichia",
                column: "fkLeituraId");

            migrationBuilder.CreateIndex(
                name: "IX_DiluicaoParaContagemMBLB_fkContagemMBLBId",
                schema: "LAB",
                table: "DiluicaoParaContagemMBLB",
                column: "fkContagemMBLBId");

            migrationBuilder.CreateIndex(
                name: "IX_DiluicaoParaContagemMBLB_fkLeituraId",
                schema: "LAB",
                table: "DiluicaoParaContagemMBLB",
                column: "fkLeituraId");

            migrationBuilder.CreateIndex(
                name: "IX_DiluicaoPorExperimento_fkDiluicaoId",
                schema: "LAB",
                table: "DiluicaoPorExperimento",
                column: "fkDiluicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DiluicaoPorExperimento_fkExperimentoId",
                schema: "LAB",
                table: "DiluicaoPorExperimento",
                column: "fkExperimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EnsaiosPorAmostra_fkAmostraId",
                schema: "LAB",
                table: "EnsaiosPorAmostra",
                column: "fkAmostraId");

            migrationBuilder.CreateIndex(
                name: "IX_EnsaiosPorAmostra_fkEnsaioId",
                schema: "LAB",
                table: "EnsaiosPorAmostra",
                column: "fkEnsaioId");

            migrationBuilder.CreateIndex(
                name: "IX_Experimento_fkDiluicaoAmostraId",
                schema: "LAB",
                table: "Experimento",
                column: "fkDiluicaoAmostraId");

            migrationBuilder.CreateIndex(
                name: "IX_Incubacao_fkExperimentoId",
                schema: "LAB",
                table: "Incubacao",
                column: "fkExperimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_fkSolicitacaoId",
                schema: "LAB",
                table: "Pergunta",
                column: "fkSolicitacaoId");

            migrationBuilder.CreateIndex(
                name: "UQ__PessoaFi__C1F8973120D239E3",
                schema: "LAB",
                table: "PessoaFisica",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__PessoaFi__C1F89731FE4ADCAE",
                schema: "LAB",
                table: "PessoaFisica",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__PessoaJu__AA57D6B424D28EF9",
                schema: "LAB",
                table: "PessoaJuridica",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__PessoaJu__AA57D6B4275C4649",
                schema: "LAB",
                table: "PessoaJuridica",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ponteira_fkDiluicaoAmostraId",
                schema: "LAB",
                table: "Ponteira",
                column: "fkDiluicaoAmostraId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_fkPessoaId",
                schema: "LAB",
                table: "Solicitacao",
                column: "fkPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_fkPessoaId",
                schema: "LAB",
                table: "Telefone",
                column: "fkPessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AguaDiluicao",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "ArquivoLaudo",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "DiluicaoParaColiformesEscherichia",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "DiluicaoParaContagemMBLB",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "DiluicaoPorExperimento",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Incubacao",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Pergunta",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "PessoaFisica",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "PessoaJuridica",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Ponteira",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Telefone",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "ColiformesEscherichia",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "ContagemMBLB",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Diluicao",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Experimento",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "EnsaiosPorAmostra",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Leitura",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "DiluicaoAmostra",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Ensaio",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Amostra",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Solicitacao",
                schema: "LAB");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "LAB");
        }
    }
}
