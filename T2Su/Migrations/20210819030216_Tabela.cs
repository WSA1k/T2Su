using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace T2Su.Migrations
{
    public partial class Tabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipomovis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipodemovimentação = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipomovis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CodigodeContainer = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EscolhaId = table.Column<int>(type: "int", nullable: false),
                    CadastroId = table.Column<int>(type: "int", nullable: false),
                    CateId = table.Column<int>(type: "int", nullable: false),
                    TipomoviId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Cadastros_CadastroId",
                        column: x => x.CadastroId,
                        principalTable: "Cadastros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Cates_CateId",
                        column: x => x.CateId,
                        principalTable: "Cates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Escolhas_EscolhaId",
                        column: x => x.EscolhaId,
                        principalTable: "Escolhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registros_Tipomovis_TipomoviId",
                        column: x => x.TipomoviId,
                        principalTable: "Tipomovis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_CadastroId",
                table: "Registros",
                column: "CadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_CateId",
                table: "Registros",
                column: "CateId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_EscolhaId",
                table: "Registros",
                column: "EscolhaId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_TipomoviId",
                table: "Registros",
                column: "TipomoviId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Escolhas");

            migrationBuilder.DropTable(
                name: "Tipomovis");
        }
    }
}
